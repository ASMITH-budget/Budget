
namespace Budget.Core
{
    class ForecastStateAccepted : ForecastState
    {
        protected override void ChangeState(Forecast forecast, ForecastFlow forecastFlow)
        {
            switch (forecastFlow)
            {
                case ForecastFlow.Pull:
                    {
                        forecast.ForecastState = new ForecastStateReady();
                        break;
                    }
            }
        }
    }
}