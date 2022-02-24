namespace Wingmann.NeuralNetwork;

/// <summary>
/// 
/// </summary>
public class Layer
{
    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public List<Neuron>? Neurons { get; }

    /// <summary>
    /// 
    /// </summary>
    public int Count => Neurons?.Count ?? 0;

    #endregion Properties

    /// <summary>
    /// 
    /// </summary>
    /// <param name="neurons"></param>
    /// <param name="type"></param>
    public Layer(List<Neuron> neurons, NeuronType type)
    {
        Neurons = neurons;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<double> GetSignals()
    {
        List<double> result = new();
        
        foreach (var neuron in Neurons!)
        {
            result.Add(neuron.Output);
        }

        return result;
    }
}
