using CapaDatos;
using CapaEntidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

//using System.Text.Json;
using System.Threading.Tasks;
using static CapaEntidad.ce_apimodels;


namespace CapaNegocio
{
    public class cn_apiservices : cd_conexionApi
    {
        /// <summary>
        /// 🔹 Obtiene los bytes crudos de una imagen alojada en el servidor.
        /// Retorna null si no está disponible o ocurre un error.
        /// </summary>
        public async Task<byte[]> ObtenerImagenBytesAsync(string fileName)
        {
            Console.WriteLine($"🚀 Descargando bytes de imagen desde servidor: {fileName}");

            try
            {
                string url = $"{baseUrl}/recibir/getimage/{fileName}";
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        byte[] bytes = await response.Content.ReadAsByteArrayAsync();
                        Console.WriteLine($"✅ Bytes de imagen recibidos: {bytes.Length} bytes");
                        return bytes;
                    }
                    else
                    {
                        Console.WriteLine($"❌ Error HTTP al descargar bytes de imagen: {response.StatusCode}");
                        string body = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Respuesta: {body}");
                    }
                }
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("⏰ La solicitud excedió el tiempo de espera (timeout).");
            }
            catch (Exception e)
            {
                Console.WriteLine($"🔥 Error descargando bytes de imagen: {e.Message}");
            }

            return null;
        }

        public async Task<byte[]> ObtenerFirmaBytesAsync(string fileName)
        {
            Console.WriteLine($"🚀 Descargando bytes de imagen desde servidor: {fileName}");

            try
            {
                string url = $"{baseUrl}/recibir/getfirma/{fileName}";
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        byte[] bytes = await response.Content.ReadAsByteArrayAsync();
                        Console.WriteLine($"✅ Bytes de imagen recibidos: {bytes.Length} bytes");
                        return bytes;
                    }
                    else
                    {
                        Console.WriteLine($"❌ Error HTTP al descargar bytes de imagen: {response.StatusCode}");
                        string body = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Respuesta: {body}");
                    }
                }
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("⏰ La solicitud excedió el tiempo de espera (timeout).");
            }
            catch (Exception e)
            {
                Console.WriteLine($"🔥 Error descargando bytes de imagen: {e.Message}");
            }

            return null;
        }

        public async Task<byte[]> ObtenerArchivoBytesAsync(string ruta)
        {
            try
            {
                string fileName = Path.GetFileName(ruta);

                Console.WriteLine($"📥 Archivo solicitado: {fileName}");

                string url =
                    $"{baseUrl}/recibir/getfile/{Uri.EscapeDataString(fileName)}";

                Console.WriteLine($"🌐 URL: {url}");

                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsByteArrayAsync();
                    }
                    else
                    {
                        string body = await response.Content.ReadAsStringAsync();

                        Console.WriteLine($"❌ Error HTTP: {response.StatusCode}");
                        Console.WriteLine(body);

                        Console.WriteLine(body);

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        /// <summary>
        /// 
        public async Task<List<EmployeeAttendanceModel>> GetEmployeeAttendanceAsync()
        {
            try
            {
                string url = $"{baseUrlExtech}/WS_GI/api/Home/ListFormats";

                Console.WriteLine($"📡 Consultando API: {url}");

                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    string json = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                        throw new Exception($"❌ Error HTTP: {response.StatusCode}");

                    // Deserializar listado
                    var lista = JsonConvert.DeserializeObject<List<EmployeeAttendanceModel>>(json);

                    if (lista == null)
                        throw new Exception("⚠️ No se pudo convertir la respuesta JSON.");

                    //Console.WriteLine($"✅ Registros obtenidos: {lista.Count}");

                    return lista;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🔥 Error GetEmployeeAttendanceAsync: {ex.Message}");
                throw;
            }
        }

        /// 🔹 Consulta información de un RUC usando la API externa apiperu.dev
        /// </summary>
        public async Task<ApiRuc> GetApiRucAsync(string ruc)
        {
            try
            {
                string url = $"{baseUrlApi}/api/ruc/{ruc}";
                string token = "a22c04e4b06e3244195120f8f0d20b7be66de8688ced6124f89d9f63dae98ddc";

                Console.WriteLine($"📡 Realizando petición HTTP GET...");
                Console.WriteLine($"🌍 URL final: {url}");

                // 🔑 Configuración de encabezados HTTP
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Authorization", $"Bearer {token}");
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("User-Agent", "CSharp-App");
                request.Headers.Add("Connection", "keep-alive");
                request.Headers.Add("Cache-Control", "no-cache");

                // 🚀 Enviar la petición
                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    string body = await response.Content.ReadAsStringAsync();

                    Console.WriteLine($"📊 Respuesta recibida - Status: {(int)response.StatusCode}");
                    Console.WriteLine($"📏 Tamaño de respuesta: {body.Length} bytes");

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("✅ Status 200 - Procesando JSON...");

                        if (string.IsNullOrWhiteSpace(body))
                            throw new Exception("⚠️ Respuesta vacía del servidor");

                        try
                        {
                            var jsonData = JsonConvert.DeserializeObject<ApiRucResponse>(body);

                            if (jsonData != null && jsonData.success && jsonData.data != null)
                            {
                                Console.WriteLine("✅ Datos de RUC procesados correctamente.");
                                return jsonData.data;
                            }
                            else
                            {
                                throw new Exception("⚠️ La respuesta no contiene datos válidos");
                            }
                        }
                        catch (JsonException e)
                        {
                            Console.WriteLine($"❌ Error al parsear JSON: {e.Message}");
                            throw new Exception("Error al procesar respuesta del servidor");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"❌ Error HTTP ({response.StatusCode})");
                        Console.WriteLine($"📄 Respuesta del servidor: {body}");

                        throw new Exception($"Error del servidor ({response.StatusCode}): {response.ReasonPhrase}");
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"🔌 Error de conexión (SocketException): {e.Message}");
                throw new Exception("Sin conexión al servidor o API inalcanzable.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"🔥 Error general al consultar RUC: {e.Message}");
                throw;
            }
        }

        public async Task<ApiResponse<List<ce_tareo_api>>> SendDestajoPorLotesAsync(
    List<ce_destajo_uva> lista,
    int batchSize = 5000)
        {
            ApiResponse<List<ce_tareo_api>> ultimaRespuesta = null;

            for (int i = 0; i < lista.Count; i += batchSize)
            {
                var lote = lista.Skip(i).Take(batchSize).ToList();

                var resp = await SendDestajoAsync(lote);

                if (!resp.Success)
                    return resp;

                ultimaRespuesta = resp;
            }

            return ultimaRespuesta;
        }



        public async Task<ApiResponse<List<ce_tareo_api>>> SendDestajoAsync(List<ce_destajo_uva> lista)
        {
            try
            {
                using (var conexion = new cd_conexionApi())
                {
                    var client = conexion.client;
                    var json = JsonConvert.SerializeObject(lista);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"{baseUrl}/FC_ASA/destajo/report_post", content);
                    string body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return new ApiResponse<List<ce_tareo_api>>
                        {
                            Success = false,
                            Message = $"Error HTTP: {(int)response.StatusCode} - {response.ReasonPhrase}\n{body}"
                        };
                    }

                    return JsonConvert.DeserializeObject<ApiResponse<List<ce_tareo_api>>>(body);
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<ce_tareo_api>>
                {
                    Success = false,
                    Message = $"Excepción: {ex.Message}"
                };
            }
        }


        public async Task<ApiResponse<List<ce_tareo_api>>> SendDestajoAsyncQA(List<ce_destajo_uva> lista)
        {
            try
            {
                using (var conexion = new cd_conexionApi())
                {
                    var client = conexion.client;
                    var json = JsonConvert.SerializeObject(lista);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"{baseUrl}/FC_ASA/destajo/report_post", content);
                    string body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return new ApiResponse<List<ce_tareo_api>>
                        {
                            Success = false,
                            Message = $"Error HTTP: {(int)response.StatusCode} - {response.ReasonPhrase}\n{body}"
                        };
                    }

                    return JsonConvert.DeserializeObject<ApiResponse<List<ce_tareo_api>>>(body);
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<ce_tareo_api>>
                {
                    Success = false,
                    Message = $"Excepción: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<List<ce_tareo_api>>> SendDestajoAsyncPRD(List<ce_destajo_uva> lista)
        {
            try
            {
                using (var conexion = new cd_conexionApi())
                {
                    var client = conexion.client;
                    var json = JsonConvert.SerializeObject(lista);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"{baseUrl}/FC_ASA/destajo/report_post", content);
                    string body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return new ApiResponse<List<ce_tareo_api>>
                        {
                            Success = false,
                            Message = $"Error HTTP: {(int)response.StatusCode} - {response.ReasonPhrase}\n{body}"
                        };
                    }

                    return JsonConvert.DeserializeObject<ApiResponse<List<ce_tareo_api>>>(body);
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<ce_tareo_api>>
                {
                    Success = false,
                    Message = $"Excepción: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<List<ce_tareo_api>>> GetDestajoRecibido()
        {
            try
            {
                using (var conexion = new cd_conexionApi())
                {
                    var response = await conexion.client.GetAsync(
                        $"{baseUrl}/FC_ASA/received/destajo");

                    var body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return new ApiResponse<List<ce_tareo_api>>
                        {
                            Success = false,
                            Message = body
                        };
                    }

                    var data = JsonConvert.DeserializeObject<List<ce_tareo_api>>(body);

                    return new ApiResponse<List<ce_tareo_api>>
                    {
                        Success = true,
                        Data = data
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<ce_tareo_api>>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse<ConfirmacionResponse>> ConfirmarDestajoRecibido()
        {
            try
            {
                using (var conexion = new cd_conexionApi())
                {
                    var response = await conexion.client.PostAsync(
                        $"{baseUrl}/FC_ASA/received/destajo/confirmar",
                        null);

                    var body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return new ApiResponse<ConfirmacionResponse>
                        {
                            Success = false,
                            Message = body
                        };
                    }

                    var data = JsonConvert.DeserializeObject<ConfirmacionResponse>(body);

                    return new ApiResponse<ConfirmacionResponse>
                    {
                        Success = true,
                        Data = data,
                        Message = data?.mensaje
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<ConfirmacionResponse>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        /*
        public async Task<ApiResponse<bool>> SendDestajoIndustrialAsync(ce_tareo_api data)
        {
            try
            {
                using (var conexion = new cd_conexionApi())
                {
                    var json = JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await conexion.client.PostAsync(
                        $"{baseUrlIndustrial}/WS_GI/api/Home/RegisterIndustrialPiecework",
                        content);

                    var body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return new ApiResponse<bool>
                        {
                            Success = false,
                            Message = body
                        };
                    }

                    return new ApiResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Enviado correctamente a Industrial"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
        */
        public async Task<ApiResponse<bool>> SendDestajoIndustrialAsyncQA(ce_tareo_api data)
        {
            try
            {
                using (var conexion = new cd_conexionApi())
                {
                    var json = JsonConvert.SerializeObject(data, Formatting.Indented);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await conexion.client.PostAsync(
                        $"{baseUrlIndustrial}/WS_GI/api/Home/RegisterIndustrialPiecework",
                        content);

                    var body = await response.Content.ReadAsStringAsync();

                    return new ApiResponse<bool>
                    {
                        Success = response.IsSuccessStatusCode,
                        Data = response.IsSuccessStatusCode,
                        StatusCode = (int)response.StatusCode,
                        Message = response.IsSuccessStatusCode
                                    ? "Enviado correctamente a Industrial"
                                    : "Error desde Industrial",
                        RawResponse = body
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = ex.Message,
                    RawResponse = ex.ToString()
                };
            }
        }

        public async Task<ApiResponse<bool>> SendDestajoIndustrialAsyncPRD(ce_tareo_api data)
        {
            try
            {
                using (var conexion = new cd_conexionApi())
                {
                    var json = JsonConvert.SerializeObject(data, Formatting.Indented);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await conexion.client.PostAsync(
                        $"{baseUrlExtech}/WS_GI/api/Home/RegisterIndustrialPiecework",
                        content);

                    var body = await response.Content.ReadAsStringAsync();

                    return new ApiResponse<bool>
                    {
                        Success = response.IsSuccessStatusCode,
                        Data = response.IsSuccessStatusCode,
                        StatusCode = (int)response.StatusCode,
                        Message = response.IsSuccessStatusCode
                                    ? "Enviado correctamente a Industrial"
                                    : "Error desde Industrial",
                        RawResponse = body
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = ex.Message,
                    RawResponse = ex.ToString()
                };
            }
        }


        //Metodo para guardar cursos
        public async Task<ce_apimodels.UploadResponse>
 SubirDocumentoAsync(string rutaArchivo, string customName)
        {
            Console.WriteLine($"🚀 Subiendo documento: {rutaArchivo}");

            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    Console.WriteLine("❌ Archivo no existe");
                    return null;
                }

                // =========================
                // 🔹 LEER ARCHIVO
                // =========================
                byte[] bytes = File.ReadAllBytes(rutaArchivo);
                string base64 = Convert.ToBase64String(bytes);

                string extension = Path.GetExtension(rutaArchivo);

                string finalFileName = customName + extension;

                // =========================
                // 🔹 REQUEST (CORRECTO)
                // =========================
                ce_apimodels.UploadRequest request =
                    new ce_apimodels.UploadRequest()
                    {
                        FileName = finalFileName,
                        Base64 = base64
                    };

                string url = $"{baseUrl}/recibir/uploadlocalcurso";

                string json =
                    Newtonsoft.Json.JsonConvert.SerializeObject(request);

                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response =
                    await client.PostAsync(url, content))
                {
                    string body =
                        await response.Content.ReadAsStringAsync();

                    Console.WriteLine(body);

                    if (response.IsSuccessStatusCode)
                    {
                        return Newtonsoft.Json.JsonConvert
                            .DeserializeObject<ce_apimodels.UploadResponse>(body);
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🔥 Error: {ex.Message}");
                return null;
            }
        }
    }

}
