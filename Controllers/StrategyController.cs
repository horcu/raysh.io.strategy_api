using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using raysh.io.strategy_api.enums;

namespace raysh.io.strategy_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrategyController : ControllerBase
    {
        public CancellationToken Token { get; set; }
        private IConnection _connection;
        private IModel _channel; 
        private IConfiguration _config;


        public StrategyController(IConfiguration config)
        {
            this._config = config;
        }
        // GET api/values
        [HttpGet]
        public async Task<JsonResult> Get(string symbol)
        {
            // init queues and insert items into the queue based on the strategy type
            try
            {
                // return the current strategy running against the passed in symbol
                return new JsonResult(StrategyType.MeanReversion);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody] object content)
        {
            // init queues and insert items into the queue based on the strategy type
            try
            {
                var body = Encoding.UTF8.GetBytes(content.ToString());
                   SetupAndAddToQueue(body);

                return new JsonResult(true);
            }
            catch (Exception)
            {
                return new JsonResult(false);
            }
        }

        private void SetupAndAddToQueue(byte[] body)
        {
            Connect();
            _channel.BasicPublish(exchange: "",
                    routingKey: "active-queue",
                    basicProperties: null,
                    body: body);
        }

        private  void Connect()
        {
             var url = _config.GetValue<string>("connections:svc:rabbit:url");
                var queueName = _config.GetValue<string>("connections:svc:rabbit:qname");
                var queueExchange = _config.GetValue<string>("connections:svc:rabbit:exchange");
                
                var factory = new ConnectionFactory { Uri = new Uri(url) };

                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(queueExchange, ExchangeType.Topic);
                _channel.QueueDeclare(queueName, true, false, false, null);
                _channel.QueueBind(queueName, queueExchange, "active-*", null);
                _channel.BasicQos(0, 1, false);

                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
               
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine("shutting down the queue");
        }
    }
}
