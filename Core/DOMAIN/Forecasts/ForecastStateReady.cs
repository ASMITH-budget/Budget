
namespace Budget.Core
{
    internal class ForecastStateReady : ForecastState
    {
        protected override void ChangeState(Forecast forecast, ForecastFlow forecastFlow)
        {

            switch (forecastFlow)
            {
                case ForecastFlow.Push:
                    {
                        forecast.ForecastState = new ForecastStateAccepted();
                        break;
                    }
                case ForecastFlow.Pull:
                    {
                        forecast.ForecastState = new ForecastStateNew();
                        break;
                    }
            }
        }
    }
}
