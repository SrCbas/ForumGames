﻿using System;
using System.Collections.Generic;
using System.Linq;
using Games.CORE.DTO;
using Games.DAL.Entities;
using Games.DAL.Repositories.Contracts;

namespace Games.DAL.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public db_gamesContext _context { get; set; }

        public UsuarioRepository(db_gamesContext context)
        {
            _context = context;
        }

        /*
         * Devuelve true si el usuario y la contraseña introducida es correcta.
         */
        public bool Login(UsuarioDTO usuarioDTO)
        {
            return _context.Users.Any(u => u.Username == usuarioDTO.Username &&
            u.Passwd == usuarioDTO.Passwd);
        }

        /*
         * Devuelve una lista con todos los usuarios.
         */
        public IEnumerable<UsuarioDTO> Get()
        {
            var usuarios = _context.Users.ToList();

            List<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();
            foreach (var i in usuarios)
            {
                var usuario = new UsuarioDTO
                {
                    Username = i.Username,
                    Group = i.Group,
                    Email = i.Email,
                    Firstname = i.FirstName,
                    Surname = i.Surname,
                    Phone = i.Phone,
                    RegisterDate = i.RegisterDate
                };
                usuariosDTO.Add(usuario);
            }
            return usuariosDTO;
        }

        /*
         * Devuelve la información de un usuario mediante su nombre.
         */
        public UsuarioDTO GetDataFromUsername(string username)
        {
            var usuario = new UsuarioDTO();

            var infoUsuario = from o in _context.Users
                              where o.Username == username
                              select o;
            foreach (var info in infoUsuario)
            {
                usuario.Username = info.Username;
                usuario.Firstname = info.FirstName;
                usuario.Surname = info.Surname;
                usuario.Group = info.Group;
                usuario.Email = info.Email;
                usuario.Phone = info.Phone;
                usuario.RegisterDate = info.RegisterDate;
            }
            return usuario;
        }

        /*
         * Guarda la información de un usuario.
         */
        public void Add(UsuarioDTO usuarioDTO)
        {
            var usuario = new Users
            {
                Username = usuarioDTO.Username,
                Passwd = usuarioDTO.Passwd,
                FirstName = usuarioDTO.Firstname,
                Surname = usuarioDTO.Surname,
                Email = usuarioDTO.Email,
                Phone = usuarioDTO.Phone
        };
            _context.Users.Add(usuario);
            _context.SaveChanges();
        }

        /*
         * Elimina un usuario.
         */
        public void Remove(UsuarioDTO usuarioDTO)
        {
            var usuarios = new Entities.Users
            {
                Username = usuarioDTO.Username
            };
            _context.Users.Remove(usuarios);
            _context.SaveChanges();
        }
    }
}
