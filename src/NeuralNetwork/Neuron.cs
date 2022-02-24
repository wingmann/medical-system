namespace Wingmann.NeuralNetwork;

/// <summary>
/// 
/// </summary>
public class Neuron
{
    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public List<double>? Weights { get; }
    
    /// <summary>
    /// Type of neuron.
    /// </summary>
    public NeuronType NeuronType { get; }

    /// <summary>
    /// 
    /// </summary>
    public double Output { get; private set; }

    #endregion Properties

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inputCount"></param>
    /// <param name="type"></param>
    public Neuron(int inputCount, NeuronType type)
    {
        NeuronType = type;
        Weights = new();

        for (var i = 0; i < inputCount; i++)
        {
            Weights.Add(1.0);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inputs"></param>
    /// <returns></returns>
    public double FeedForward(List<double> inputs)
    {
        var sum = 0.0;

        if (Weights is null)
        {
            return sum;
        }

        for (var i = 0; i < inputs.Count; i++)
        {
            sum += inputs[i] * Weights[i];
        }

        return Output = Sigmoid(sum);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="weights"></param>
    public void SetWeights(params double[] weights)
    {
        for (var i = 0; i < weights.Length; i++)
        {
            Weights![i] = weights[i]; 
        }
    }

    private static double Sigmoid(double value) => 1.0 / (1.0 + Math.Exp(-value));

#if DEBUG
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString() => Output.ToString();
#endif
}
