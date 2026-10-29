using CapaDatos;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidad.ce_nisira_api;

namespace CapaNegocio
{
    /// <summary>
    /// Cliente del API REST de NISIRA (ver "NISIRA - Manual del Programador").
    /// Sigue el mismo patrón que <see cref="cn_apiservices"/>: una instancia
    /// de <see cref="cd_conexionApi"/> por llamada, respuestas envueltas en
    /// <see cref="CapaEntidad.ApiResponse{T}"/>.
    /// </summary>
    public class cn_apinisira
    {
        // =====================================================================
        // 🔑 Credenciales del API (ver ITEM 001 del manual - servicio "loginb2b").
        // TODO: confirmar/rotar con el administrador de NISIRA si corresponde.
        // =====================================================================
        private static string TokenCliente { get { return cd_conexionApi.tokenClienteNisira; } }
        private static string DataSourceIdProd { get { return cd_conexionApi.dataSourceIdNisira; } }

        /// <summary>
        /// 1) Hace login contra NISIRA ("loginb2b") y devuelve el JWT a usar
        /// como Bearer token en el resto de llamadas.
        /// </summary>
        public async Task<CapaEntidad.ApiResponse<string>> LoginAsync()
        {
            try
            {
                using (var conexion = new cd_conexionApi())
                {
                    var request = new NisiraTokenRequest
                    {
                        token = TokenCliente,
                        datasourceid = DataSourceIdProd
                    };

                    var json = JsonConvert.SerializeObject(request);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await conexion.client.PostAsync(
                        $"{cd_conexionApi.baseUrlNisira}/loginb2b", content);

                    var body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return new CapaEntidad.ApiResponse<string>
                        {
                            Success = false,
                            StatusCode = (int)response.StatusCode,
                            Message = $"Error HTTP al autenticar en NISIRA: {(int)response.StatusCode} - {response.ReasonPhrase}",
                            RawResponse = body
                        };
                    }

                    var data = JsonConvert.DeserializeObject<NisiraTokenResponse>(body);

                    if (data?.data?.token == null)
                    {
                        return new CapaEntidad.ApiResponse<string>
                        {
                            Success = false,
                            Message = "NISIRA no devolvió un token válido.",
                            RawResponse = body
                        };
                    }

                    return new CapaEntidad.ApiResponse<string>
                    {
                        Success = true,
                        Data = data.data.token
                    };
                }
            }
            catch (Exception ex)
            {
                return new CapaEntidad.ApiResponse<string>
                {
                    Success = false,
                    Message = $"Excepción al autenticar en NISIRA: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// 2) Lista las órdenes de liquidación de gastos ya registradas en
        /// NISIRA dentro de un rango de fechas. Solo lectura: sirve para
        /// validar (botón "QA NISIRA") antes de enviar nada.
        /// </summary>
        public async Task<CapaEntidad.ApiResponse<System.Collections.Generic.List<NisiraLiquidacionListado>>>
            ListarLiquidacionesAsync(string token, DateTime fechaIni, DateTime fechaFin,
                string idestado = "", string idarea = "", string documento = "")
        {
            try
            {
                using (var conexion = new cd_conexionApi())
                {
                    var filtro = new NisiraListadoFiltro
                    {
                        idestado = idestado ?? "",
                        idarea = idarea ?? "",
                        documento = documento ?? "",
                        fechaini = fechaIni.ToString("yyyyMMdd"),
                        fechafin = fechaFin.ToString("yyyyMMdd")
                    };

                    var json = JsonConvert.SerializeObject(filtro);

                    var request = new HttpRequestMessage(HttpMethod.Get,
                        $"{cd_conexionApi.baseUrlNisira}/api/liquidacion-gasto/list/liquidacion-gasto")
                    {
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var response = await conexion.client.SendAsync(request);
                    var body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return new CapaEntidad.ApiResponse<System.Collections.Generic.List<NisiraLiquidacionListado>>
                        {
                            Success = false,
                            StatusCode = (int)response.StatusCode,
                            Message = $"Error HTTP al listar en NISIRA: {(int)response.StatusCode} - {response.ReasonPhrase}",
                            RawResponse = body
                        };
                    }

                    var data = JsonConvert.DeserializeObject<NisiraListadoResponse>(body);

                    return new CapaEntidad.ApiResponse<System.Collections.Generic.List<NisiraLiquidacionListado>>
                    {
                        Success = true,
                        Data = data?.data ?? new System.Collections.Generic.List<NisiraLiquidacionListado>(),
                        RawResponse = body
                    };
                }
            }
            catch (Exception ex)
            {
                return new CapaEntidad.ApiResponse<System.Collections.Generic.List<NisiraLiquidacionListado>>
                {
                    Success = false,
                    Message = $"Excepción al listar en NISIRA: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// 3) Registra una orden de liquidación de gasto (cabecera + detalle)
        /// en NISIRA. Este es el envío real (botón "ENVIAR A NISIRA").
        /// </summary>
        public async Task<CapaEntidad.ApiResponse<NisiraSaveResponse>> GuardarLiquidacionAsync(
            string token, NisiraLiquidacionRequest documento)
        {
            try
            {
                using (var conexion = new cd_conexionApi())
                {
                    var json = JsonConvert.SerializeObject(documento);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var request = new HttpRequestMessage(HttpMethod.Post,
                        $"{cd_conexionApi.baseUrlNisira}/api/liquidacion-gasto/save")
                    {
                        Content = content
                    };
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var response = await conexion.client.SendAsync(request);
                    var body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        // 400 (validación) o 500 (excepción): el manual define
                        // ambos con forma de NisiraErrorResponse.
                        string mensaje;
                        try
                        {
                            var error = JsonConvert.DeserializeObject<NisiraErrorResponse>(body);
                            if (error?.data != null && error.data.Count > 0)
                            {
                                mensaje = string.Join(" | ", error.data.ConvertAll(d => d.message));
                            }
                            else
                            {
                                mensaje = error?.message ?? $"Error HTTP {(int)response.StatusCode}";
                            }
                        }
                        catch
                        {
                            mensaje = $"Error HTTP {(int)response.StatusCode} - {response.ReasonPhrase}";
                        }

                        return new CapaEntidad.ApiResponse<NisiraSaveResponse>
                        {
                            Success = false,
                            StatusCode = (int)response.StatusCode,
                            Message = mensaje,
                            RawResponse = body
                        };
                    }

                    var data = JsonConvert.DeserializeObject<NisiraSaveResponse>(body);

                    return new CapaEntidad.ApiResponse<NisiraSaveResponse>
                    {
                        Success = data != null && !data.error,
                        Data = data,
                        Message = data?.message,
                        RawResponse = body
                    };
                }
            }
            catch (Exception ex)
            {
                return new CapaEntidad.ApiResponse<NisiraSaveResponse>
                {
                    Success = false,
                    Message = $"Excepción al registrar en NISIRA: {ex.Message}"
                };
            }
        }
    }
}
