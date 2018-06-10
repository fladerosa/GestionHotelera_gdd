﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrbaHotel.Repositorios;
using System;
using TestingFrbaHotel.ModelBuilder;
using FrbaHotel.Modelo;

namespace TestingFrbaHotel
{
    [TestClass]
    public class TestRepositorioHabitacion
    {
        /* ESTE TEST PINCHA
        [TestMethod]
        public void create_OK()
        {
            RepositorioHabitacion  repositorioHabitacion = new RepositorioHabitacion();
            RepositorioHotel repositorioHotel = new RepositorioHotel();
            RepositorioTipoHabitacion repositorioTipoHabitacion = new RepositorioTipoHabitacion();
            Hotel hotel = HotelBuilder.buildHotel();
            TipoHabitacion tipoHabitacion = TipoHabitacionBuilder.build();
            int idTipoHabitacion= repositorioTipoHabitacion.create(tipoHabitacion);
            //tipoHabitacion.idTipoHabitacion = idTipoHabitacion;
            tipoHabitacion.setIdTipoHabitacion(idTipoHabitacion);
            int idHotel = repositorioHotel.create(hotel);
            hotel.IdHotel = idHotel;
            Habitacion habitacion = HabitacionBuilder.buildHabitacion(tipoHabitacion, idHotel);

            int idHabitacion=repositorioHabitacion.create(habitacion);
            habitacion.setIdHabitacion(idHabitacion);
            Habitacion habitacionSearched = repositorioHabitacion.getById(idHabitacion);

            //ASSERT DE HABITACION
            Assert.AreEqual(habitacion.IdHabitacion, habitacionSearched.IdHabitacion);
            Assert.AreEqual(habitacion.Numero, habitacionSearched.Numero);
            Assert.AreEqual(habitacion.Piso, habitacionSearched.Piso);
            Assert.AreEqual(habitacion.Ubicacion, habitacionSearched.Ubicacion);
            Assert.AreEqual(habitacion.Activa, habitacionSearched.Activa);

            //ASSERT DE TIPO_DE_HABITACION

            Assert.AreEqual(habitacion.TipoHabitacion.Descripcion, habitacionSearched.TipoHabitacion.Descripcion);
            Assert.AreEqual(habitacion.TipoHabitacion.Codigo, habitacionSearched.TipoHabitacion.Codigo);
            Assert.AreEqual(habitacion.TipoHabitacion.Porcentual, habitacionSearched.TipoHabitacion.Porcentual);


            //ASSERT idHotel
            Assert.AreEqual(habitacion.IdHotel, habitacionSearched.IdHotel);

            //IN_PROGRESS. Gabriel


        }
        */

    }
}