using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using raysh.io.strategy_api.enums;

namespace raysh.io.strategy_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrategyController : ControllerBase
    {
        public StrategyController(IModel _channel) 
        {
            this._channel = _channel;
               
        }
                private IModel _channel { get; set; }

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
                   await SetupAndAddToQueue(body);

                return new JsonResult(true);
            }
            catch (Exception ex)
            {
                return new JsonResult(false);
            }
        }

        private async Task SetupAndAddToQueue(byte [] body)
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            using var connection = factory.CreateConnection();
            using (await Task.FromResult(_channel = connection.CreateModel()))
            {
                 _channel.BasicPublish(exchange: "",
                    routingKey: "strategy-queue",
                    basicProperties: null,
                    body: body);
            }
        }
    }
}
