
namespace Budget.Core
{
    internal abstract class ForecastState
    {
        internal virtual void HandleState(Forecast forecast, ForecastFlow forecastFlow)
        {
            ChangeState(forecast, forecastFlow);
        }
        protected abstract void ChangeState(Forecast forecast, ForecastFlow forecastFlow);
    }
}