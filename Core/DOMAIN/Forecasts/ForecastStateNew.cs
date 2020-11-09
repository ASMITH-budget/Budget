
namespace Budget.Core
{
    internal class ForecastStateNew : ForecastState
    {
        protected override void ChangeState(Forecast forecast, ForecastFlow forecastFlow)
        {
            switch (forecastFlow)
                {
                    case ForecastFlow.Push:
                    {
                        forecast.ForecastState = new ForecastStateReady();
                        break;
                    }
                }
            
        }
    }
}
