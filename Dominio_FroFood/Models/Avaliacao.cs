﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_FroFood.Models
{
    public class Avaliacao
    {
        public Guid Id { get; set; }
        public string Comentario { get; set; }
        public int Nota { get; set; }
        public Guid ReatauranteID { get; set; }
        public Guid ClienteId { get; set; }
        //TODO
        //Adicionar imagem
    }
}