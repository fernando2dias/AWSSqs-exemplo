using System;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

//var cliente = new AmazonSQSClient(RegionEndpoint.USEast1);
var client = new AmazonSQSClient();

//pegando a url da fila...
var queueUrlResponse = await client.GetQueueUrlAsync("fernando-test");

var request = new SendMessageRequest
{
    QueueUrl = queueUrlResponse.QueueUrl,
    MessageBody = "teste 123"
};

await client.SendMessageAsync(request);