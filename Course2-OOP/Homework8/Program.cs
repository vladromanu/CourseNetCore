using Homework8.Models;
using Homework8.Models.Enums;
using Homework8.Models.Interfaces;
using Homework8.Models.Logger;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Homework8
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            //ILogger logger = new FileLogger();

            logger.Log("Journey begins ...\n");

            // Alex intended to buy a Ford Focus 2015 model.
            Customer Alex = new Customer("Alex")
            {
                Logger = logger
            };

            // He walked to the FordStore in Bucuresti and agreed to buy one for *15000Euro.
            FordStore fordStore = new FordStore();
            Alex.WalkToStore(fordStore);
            Car fordCar = Alex.PickCar(fordStore);

            Order fordOrder = fordStore.RegisterOrder(Alex, fordCar);
            logger.Log($"Order <{fordOrder.OrderId}> has been placed. \n Car: {fordOrder.Car} \n Status <{fordOrder.Status}> \n Date <{fordOrder.ConfirmationDate}>");

            // They informed him it will take 4 weeks for delivery.
            logger.Log($"Order <{fordOrder.OrderId}> will take <{fordOrder.DeliveryTime}> weeks to deliver\n");

            // He then decided to visit another store SkodaStore and agreed to buy one * for 14000Euro and 3 weeks delivery.
            Store skodaStore = new SkodaStore();
            Alex.WalkToStore(skodaStore);
            Car skodaCar = Alex.PickCar(skodaStore);

            Order skodaOrder = skodaStore.RegisterOrder(Alex, skodaCar);
            logger.Log($"Order <{skodaOrder.OrderId}> has been placed. \n Car: {skodaOrder.Car} \n Status <{skodaOrder.Status}> \n Date <{skodaOrder.ConfirmationDate}>");
            
            // They informed him it will take 3 weeks for delivery.
            logger.Log($"Order <{skodaOrder.OrderId}> will take <{skodaOrder.DeliveryTime}> weeks to deliver\n");

            // He then canceled his original order from the FordStore.
            OrderStatus cancellationStatus;
            try
            {
                cancellationStatus = fordStore.CancelOrder(fordOrder);
            }
            catch (Exception ex)
            {
                logger.Log($"Could not cancel order: {ex.Message}");
                return;
            }

            if (cancellationStatus != OrderStatus.CANCELLED)
            {
                logger.Log($"Order <{fordOrder.OrderId}> could not be cancelled.");
                return;
            }

            logger.Log($"Order <{fordOrder.OrderId}> has been cancelled.");


            // After 3 weeks, he received the model.
            Thread.Sleep(300); // sleep for a while 0.3s

            OrderStatus deliveryStatus;
            try
            {
                deliveryStatus = skodaStore.DeliverOrder(skodaOrder);
            }
            catch (Exception ex)
            {
                logger.Log($"Could not deliver order: {ex.Message}");
                return;
            }

            if (deliveryStatus != OrderStatus.DELIVERED)
            {
                logger.Log($"Order <{fordOrder.OrderId}> could not be delivered.");
                return;
            }

            logger.Log($"Order <{skodaOrder.OrderId}> has been delivered. \nCar: {skodaOrder.Car} \nStatus: <{skodaOrder.Status}> \nDelivery Date: <{skodaOrder.DeliveryDate}>");

            logger.Close();
        }

    }
}
