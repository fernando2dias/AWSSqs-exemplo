using System;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

//var cliente = new AmazonSQSClient(RegionEndpoint.USEast1);
var client = new AmazonSQSClient();

//pegando a url da fila...
var queueUrlResponse = await client.GetQueueUrlAsync("fernando-test");

var request = new ReceiveMessageRequest
{
    QueueUrl = queueUrlResponse.QueueUrl
};



while (true)
{
    var response = await client.ReceiveMessageAsync(request);

    foreach (var message in response.Messages)
    {
        Console.WriteLine(message.Body);

        //tirar da fila
        await client.DeleteMessageAsync(queueUrlResponse.QueueUrl, message.ReceiptHandle);
    }

}

