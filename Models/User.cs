﻿namespace muriel_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
