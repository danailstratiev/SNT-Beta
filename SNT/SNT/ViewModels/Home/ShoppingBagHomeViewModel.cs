﻿using AutoMapper;
using SNT.Models;
using SNT.ServiceModels;
using SNT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.ViewModels.Home
{
    public class ShoppingBagHomeViewModel : IMapFrom<ShoppingBagServiceModel>
    {
        public ShoppingBagHomeViewModel(HashSet<ShoppingBagTyre> tyres,
            HashSet<ShoppingBagWheelRim> wheelRims,
             HashSet<ShoppingBagMotorOil> motorOils, string userId)
        {
            this.Tyres = tyres;

            this.WheelRims = wheelRims;

            this.MotorOils = motorOils;

            this.UserId = userId;
        }

        public string UserId { get; set; }

        public HashSet<ShoppingBagTyre> Tyres { get; set; }
        public HashSet<ShoppingBagWheelRim> WheelRims { get; set; }
        public HashSet<ShoppingBagMotorOil> MotorOils { get; set; }

        public decimal TotalSum { get => Sum(); }

        public decimal Sum()
        {
            var sum = 0m;

            foreach (var tyre in this.Tyres)
            {
                sum += tyre.Price*tyre.Quantity;
            }

            foreach (var wheelRim in this.WheelRims)
            {
                sum += wheelRim.Price*wheelRim.Quantity;
            }

            foreach (var motorOil in this.MotorOils)
            {
                sum += motorOil.Price* motorOil.Quantity;
            }

            return sum;
        }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration
        //       .CreateMap<ShoppingBagServiceModel, ShoppingBagHomeViewModel>();
        //}
    }
}
