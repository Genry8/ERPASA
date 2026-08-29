namespace CapaEntidad
{
    public class ce_apimodels
    {
        // ========================
        // 🔹 Clases de modelo JSON
        // ========================
        public class ApiRucResponse
        {
            public bool success { get; set; }
            public ApiRuc data { get; set; }
        }

        public class ApiRuc
        {
            public string ruc { get; set; }
            public string razon_social { get; set; }
            public string nombre_comercial { get; set; }
            public string direccion { get; set; }
            public string estado { get; set; }
            public string condicion { get; set; }
            public string ubigeo { get; set; }
            public string departamento { get; set; }
            public string provincia { get; set; }
            public string distrito { get; set; }
            public string fecha_inscripcion { get; set; }
        }

        // ========================
        // 🔹 REQUEST (SUBIR ARCHIVO)
        // ========================
        public class UploadRequest
        {
            public string FileName { get; set; }

            public string CustomName { get; set; }

            public string Base64 { get; set; }
        }

        // ========================
        // 🔹 RESPONSE (SUBIR ARCHIVO)
        // ========================
        public class UploadResponse
        {
            public bool success { get; set; }

            // nombre del archivo guardado
            public string name { get; set; }

            // ruta física en servidor
            public string path { get; set; }

            // URL pública (⭐ IMPORTANTE)
            public string url { get; set; }

            public long size { get; set; }

            public string mimeType { get; set; }

            public string message { get; set; }
        }

    }
}
