using System;
using System.Threading;
using Grpc.Net.Client;
using OzonEdu.MerchandiseService.Grpc;

using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new MerchandiseServiceGrpc.MerchandiseServiceGrpcClient(channel);


var orderId = client.AskMerchandise(new AskMerchandiseRequest(), cancellationToken: CancellationToken.None);
Console.WriteLine($"Order ID: {orderId.OrderId}");

var orderStatus = client.CheckMerchandise(new MerchandiseOrderIdRequest(), cancellationToken: CancellationToken.None);
Console.WriteLine($"Order Status: {orderStatus.OrderStatus}");