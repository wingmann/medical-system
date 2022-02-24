namespace Wingmann.NeuralNetwork;

/// <summary>
/// 
/// </summary>
public class Topology
{
    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public int InputCount { get; }

    /// <summary>
    /// 
    /// </summary>
    public int OutputCount { get; }

    /// <summary>
    /// 
    /// </summary>
    public List<int>? HiddenLayers { get; }

    #endregion Properties

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inputCount"></param>
    /// <param name="outputCount"></param>
    /// <param name="layers"></param>
    public Topology(int inputCount, int outputCount, params int[] layers)
    {
        InputCount = inputCount;
        OutputCount = outputCount;

        HiddenLayers = new();
        HiddenLayers.AddRange(layers);
    }
}
