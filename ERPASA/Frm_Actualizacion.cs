using Auth0.ManagementApi.Models;
using CapaEntidad;
using Guna.UI2.WinForms;
//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Download;
//using Google.Apis.Drive.v3;
//using Google.Apis.Services;
//using Google.Apis.Util.Store;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Windows.Media;

namespace ERPASA
{
    public partial class Frm_Actualizacion : Form
    {
        // Configuración
        //static string servidor = "https://drive.google.com/drive/folders/1GIAtkK3z5QjRXbFzKpOqV2W39aQ0pIAT?usp=sharing";
        //Frm_Login frmLogin = new Frm_Login();  // Instancia del formulario de login para acceder a la versión actual
        static string versionActual = ce_version.version_act;  // Esta es la versión actual de la app (puede venir desde tu aplicación principal)
        static string rutaDestino = Application.StartupPath;//Application.StartupPath;  // Ruta de la aplicación

        public Frm_Actualizacion()
        {
            InitializeComponent();
        }

        private void Frm_Actualizacion_Load_1(object sender, EventArgs e)
        {
            // Cambiar el color de fondo
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(10);

            // Ajustar la caja de texto
            statusLabel.BorderStyle = BorderStyle.None;
            statusLabel.Font = new System.Drawing.Font("Segoe UI", 9);

            // Sombra en el formulario
            this.Region = new System.Drawing.Region(new System.Drawing.Rectangle(0, 0, this.Width, this.Height));

            // Iniciar actualización en un hilo separado para no bloquear la UI
            Thread actualizarThread = new Thread(new ThreadStart(ActualizarApp));
            actualizarThread.Start();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private async void ActualizarApp()
        {
            try
            {
                // Iniciar la autenticación con Google Drive
                //DriveService service = await GoogleDriveAuth.AuthenticateAsync();


                // ID del archivo que quieres descargar de Google Drive
                //string fileId = "1Uf0Twj6b0_Qghx2QqsW9oq1JNurD6jH6";  // Sustituye con el ID del archivo

                string urlGitHub = "https://github.com/Genry8/asa_app/releases/download/v1.0/publish.zip";

                // Ruta donde se guardará el archivo descargado en el directorio de la aplicación
                //string rutaArchivo = Path.Combine(Path.GetTempPath(), "publish.zip");  // Nombre del archivo descargado
                string rutaArchivo = Path.Combine(Path.GetTempPath(), "publish.zip");  // Usar una ruta más corta


                // Verificar y crear directorios si no existen
                VerificarYCrearRuta(rutaArchivo);

                // Ahora puedes continuar con la extracción o cualquier otro proceso
                // Verificar la ruta antes de la descarga
                if (!VerificarRutaArchivo(rutaArchivo))
                {
                    return;
                }

                // Iniciar la descarga con el progreso
                SetStatus("Descargando archivo...");
                progressBar1.Value = 0; // Inicializar el ProgressBar

                // Descargar el archivo usando la API de Google Drive con progreso
                //await DescargarArchivoDesdeDrive(service, fileId, rutaArchivo);
                //DescargarArchivoConHttpClient(fileId, rutaArchivo);
                await DescargarArchivoDesdeGitHub(urlGitHub, rutaArchivo);

                // Verificar que el archivo se haya descargado correctamente
                if (!VerificarArchivoDescargado(rutaArchivo))
                {
                    SetStatus("Error: El archivo no se descargó correctamente.");
                    return;
                }

                // Verificar si el archivo descargado es un archivo ZIP válido
                if (!EsZipValido(rutaArchivo))
                {
                    SetStatus("Error: El archivo ZIP descargado está corrupto.");
                    return;
                }

                // Actualizar la interfaz de usuario
                SetStatus("Comprobando actualización...");

                // Verificar si la versión está actualizada
                if (ce_usuario.version_actual != versionActual)
                {
                    SetStatus($"Nueva versión disponible: {ce_usuario.version_actual}. Descargando...");

                    // Descomprimir el archivo ZIP con progreso
                    SetStatus("Descomprimiendo archivo...");
                    await ExtraerArchivosConSharpZipLib(rutaArchivo);  // Usamos descompresión asincrónica

                    //SetStatus("Cerrando la aplicación...");
                    //CerrarAplicacion();

                    SetStatus("Instalando nueva versión...");
                    ReemplazarArchivos();

                    //SetStatus("Actualización completada. Iniciando nueva versión...");
                    ////Process.Start(Path.Combine(rutaDestino, "setup.exe"));
                    //string carpetaTemporal = Path.Combine(Path.GetTempPath(), "actualizacion_temp");
                    //string rutaSetup = Path.Combine(carpetaTemporal, "publish");
                    //Process.Start(Path.Combine(rutaSetup, "setup.exe"));

                    //CerrarAplicacion();
                    SetStatus("Actualización completada. Iniciando nueva versión...");

                    string carpetaTemporal = Path.Combine(Path.GetTempPath(), "actualizacion_temp");
                    string rutaSetup = Path.Combine(carpetaTemporal, "publish", "setup.exe");

                    try
                    {
                        // Inicia el instalador
                        Process.Start(rutaSetup);

                        // Espera un momento para asegurar que el proceso hijo arranque correctamente
                        await Task.Delay(2000);

                        // Cierra la aplicación actual
                        //h
                        CerrarAplicacion();
                    }
                    catch (Exception ex)
                    {
                        SetStatus($"Error al iniciar el instalador: {ex.Message}", true);
                        // Aquí no cerramos la app para que el usuario pueda ver el error
                    }


                }
                else
                {
                    SetStatus("Ya tienes la última versión.");
                }
            }
            catch (Exception ex)
            {
                SetStatus($"Error durante la actualización:\r\n{ex.Message}", isError: true);
            }
        }

        private void SetStatus(string mensaje, bool isError = false)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetStatus(mensaje, isError)));
                return;
            }

            statusLabel.Text = mensaje;

            if (isError)
            {
                statusLabel.Font = new Font(statusLabel.Font.FontFamily, 8); // tamaño más pequeño                
            }
            else
            {
                statusLabel.Font = new Font(statusLabel.Font.FontFamily, 10); // tamaño normal
            }
        }


        private void VerificarYCrearRuta(string ruta)
        {
            string directorio = Path.GetDirectoryName(ruta);

            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
        }

        private async Task DescargarArchivoDesdeGitHub(string url, string rutaDestino)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();

                    long totalBytes = response.Content.Headers.ContentLength ?? 1;
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = new FileStream(rutaDestino, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        byte[] buffer = new byte[8192];
                        int bytesRead;
                        long totalRead = 0;

                        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            totalRead += bytesRead;

                            int progress = (int)((double)totalRead * 100 / totalBytes);
                            progressBar1.Invoke(new MethodInvoker(() =>
                            {
                                progressBar1.Value = Math.Min(progress, 100);
                            }));
                            SetStatus($"Descargando... {totalRead / 1024 / 1024} MB, paciencia porfavor");
                        }
                    }
                }

                SetStatus("Descarga completada.");
            }
            catch (Exception ex)
            {
                SetStatus($"Error al descargar desde GitHub: {ex.Message}");
            }
        }

        private bool VerificarRutaArchivo(string ruta)
        {
            try
            {
                // Verifica si el directorio existe
                string directorio = Path.GetDirectoryName(ruta);
                if (!Directory.Exists(directorio))
                {
                    SetStatus("Error: El directorio no existe.");
                    return false;
                }

                // Verificar si el archivo ya existe
                if (File.Exists(ruta))
                {
                    SetStatus("Advertencia: El archivo ya existe. Se sobrescribirá.");
                }

                return true;
            }
            catch (Exception ex)
            {
                SetStatus($"Error al verificar la ruta: {ex.Message}");
                return false;
            }
        }

        private bool VerificarArchivoDescargado(string archivo)
        {
            try
            {
                // Verifica si el archivo existe y si su tamaño es mayor que 0
                if (!File.Exists(archivo))
                {
                    SetStatus($"Error: El archivo no existe en la ruta: {archivo}");
                    return false;
                }

                long tamañoArchivo = new FileInfo(archivo).Length;
                if (tamañoArchivo == 0)
                {
                    SetStatus($"Error: El archivo descargado está vacío. Tamaño: {tamañoArchivo} bytes.");
                    return false;
                }

                SetStatus($"El archivo fue descargado correctamente. Tamaño: {tamañoArchivo} bytes.");
                return true;
            }
            catch (Exception ex)
            {
                SetStatus($"Error al verificar el archivo: {ex.Message}");
                return false;
            }
        }

        private bool EsZipValido(string archivoZip)
        {
            try
            {
                using (FileStream fs = new FileStream(archivoZip, FileMode.Open, FileAccess.Read))
                using (ZipArchive archive = new ZipArchive(fs, ZipArchiveMode.Read))
                {
                    return archive.Entries.Count > 0;  // Verifica que el archivo tenga al menos una entrada
                }
            }
            catch
            {
                return false;  // El archivo no es un ZIP válido
            }
        }

        private void ReemplazarArchivos()
        {
            string carpetaTemporal = Path.Combine(Path.GetTempPath(), "actualizacion_temp");

            foreach (var file in Directory.GetFiles(carpetaTemporal, "*", SearchOption.AllDirectories))
            {
                try
                {
                    string rutaRelativa = GetRelativePath(carpetaTemporal, file);
                    string destinoCompleto = Path.Combine(rutaDestino, rutaRelativa);

                    string carpeta = Path.GetDirectoryName(destinoCompleto);
                    if (!Directory.Exists(carpeta))
                        Directory.CreateDirectory(carpeta);

                    // Comprobar si el archivo está en uso
                    if (EstaEnUso(destinoCompleto))
                    {
                        SetStatus($"Archivo en uso, se omitirá temporalmente: {destinoCompleto}");
                        continue;
                    }

                    File.Copy(file, destinoCompleto, true);
                }
                catch (Exception ex)
                {
                    SetStatus($"Error al copiar {file}: {ex.Message}");
                }
            }
        }

        private bool EstaEnUso(string filePath)
        {
            if (!File.Exists(filePath)) return false;

            try
            {
                using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    // Si se puede abrir, no está en uso
                }
                return false;
            }
            catch (IOException)
            {
                return true;
            }
        }

        private void CerrarAplicacion()
        {
            //string processName = Process.GetCurrentProcess().ProcessName;
            foreach (Process p in Process.GetProcessesByName("ERPASA"))
            {
                try
                {
                    p.Kill();
                    p.WaitForExit();
                }
                catch { }
            }
        }

        public static string GetRelativePath(string fromPath, string toPath)
        {
            Uri fromUri = new Uri(fromPath);
            Uri toUri = new Uri(toPath);

            // Si las rutas son relativas, no podemos hacer nada
            if (fromUri.Scheme != toUri.Scheme)
                return toPath;

            Uri relativeUri = fromUri.MakeRelativeUri(toUri);
            return Uri.UnescapeDataString(relativeUri.ToString());
        }

        public async Task ExtraerArchivosConSharpZipLib(string archivoZip)
        {
            string carpetaDestino = Path.Combine(Path.GetTempPath(), "actualizacion_temp");

            // Verificar si la carpeta ya existe y eliminarla si es necesario
            if (Directory.Exists(carpetaDestino))
                Directory.Delete(carpetaDestino, true);

            // Crear la carpeta destino
            Directory.CreateDirectory(carpetaDestino);

            using (ICSharpCode.SharpZipLib.Zip.ZipFile zip = new ICSharpCode.SharpZipLib.Zip.ZipFile(archivoZip))
            {
                long totalBytes = zip.Count;
                long extractedBytes = 0;

                foreach (ZipEntry entry in zip)
                {
                    string filePath = Path.Combine(carpetaDestino, entry.Name);
                    string directoryPath = Path.GetDirectoryName(filePath);

                    // Asegurarse de que el directorio de destino exista
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    if (!entry.IsDirectory)
                    {
                        using (Stream zipStream = zip.GetInputStream(entry))
                        using (FileStream fs = File.Create(filePath))
                        {
                            // Usamos CopyToAsync para hacer la operación asincrónica
                            await zipStream.CopyToAsync(fs);

                            extractedBytes += entry.Size;
                            int progress = (int)((double)extractedBytes * 100 / totalBytes);


                            // Asegurarse de actualizar la progressBar en el hilo principal (UI thread)
                            progressBar1.Invoke((MethodInvoker)(() =>
                            {
                                // Asegurarse de que el valor de la barra de progreso no pase de 100
                                progressBar1.Value = Math.Min(progress, 100);  // Actualizar la progressBar1
                            }));

                            // Si necesitas un valor más preciso:
                            SetStatus($"Descomprimiendo archivo... {progress} completado");
                        }
                    }
                }
            }

            SetStatus("Descompresión completada.");
        }


        private void SetStatus(string status)
        {
            if (statusLabel.InvokeRequired)
            {
                statusLabel.Invoke(new Action(() => statusLabel.Text = status));
            }
            else
            {
                statusLabel.Text = status;
            }
        }

    }
}
