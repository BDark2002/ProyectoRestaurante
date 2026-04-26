using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public  class Restaurante
    {

        private readonly DL.Models.RestauranteContext _context;

        public Restaurante(DL.Models.RestauranteContext context)
        {
            _context = context;
        }

        public ML.Result GetAllRestaurante()
        {
            ML.Result result = new ML.Result();

            try
            {
                var query = _context.SPGetAll
                    .FromSqlRaw("EXEC RestauranteGetAllJ")
                    .ToList();

                if (query.Count > 0)
                {
                    result.Objects = new List<object>();

                    foreach (var item in query)
                    {
                        ML.Restaurante restaurante = new ML.Restaurante();

                        restaurante.IdRestaurante = item.IdRestaurante;
                        restaurante.Nombre = item.Nombre;
                        //restaurante.Logo = item.Logo;
                        restaurante.FechaApertura = item.FechaApertura;
                        restaurante.FechaCierre = item.FechaCierre;

                        // Dirección (solo ID)
                        restaurante.Direccion = new ML.Direccion();
                        restaurante.Direccion.IdDireccion = item.IdDireccion;

                        // Colonia
                        restaurante.Direccion.Colonia = new ML.Colonia();
                        restaurante.Direccion.Colonia.Nombre = item.NombreColonia;

                        // Municipio
                        restaurante.Direccion.Colonia.Municipio = new ML.Municipio();
                        restaurante.Direccion.Colonia.Municipio.Nombre = item.NombreMunicipio;

                        // Estado
                        restaurante.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        restaurante.Direccion.Colonia.Municipio.Estado.Nombre = item.NombreEstado;

                        result.Objects.Add(restaurante);
                    }

                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontraron registros.";
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
     public ML.Result DeleteRestaurante (int idRestaurante){
        Ml.Result result = new Ml.Result();

        try{
          int rowsAffected = _context.Database.Execute.Sql.Raw(
            "EXEC RestauranteDelete @IdRestaurante = {0}",
            idRestaurante);

          result.Correct = rowsAffected > 0;
        }
     }catch(Exception ex){
        result.Correct = false;
        result.ErrorMessage= ex.Message;
        result.Ex=ex;
     }
     return result;
    }

    
}
