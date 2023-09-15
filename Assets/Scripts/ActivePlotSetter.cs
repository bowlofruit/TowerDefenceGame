using TowerDefence;

public class ActivePlotSetter
{
    private static PlotController _activePlot;

    public static PlotController ActivePlot { get => _activePlot; set => _activePlot = value; }
}
