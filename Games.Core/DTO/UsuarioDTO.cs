﻿using System;

namespace Games.CORE.DTO
{
    public class UsuarioDTO
    {
        public string Username { get; set;}
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }

        public UsuarioDTO() {}
    }
}
