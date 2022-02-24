namespace Wingmann.NeuralNetwork;

/// <summary>
/// 
/// </summary>
public class Network
{
    #region Properties

    public Topology Topology { get; }

    /// <summary>
    /// 
    /// </summary>
    public List<Layer>? Layers { get; }

    #endregion Properties

    /// <summary>
    /// 
    /// </summary>
    public Network(Topology topology)
    {
        Topology = topology;
        Layers = new();
    }

    private void SendSignalsToInputNeurons(List<double> inputSignals)
    {
        for (var i = 0; i < inputSignals.Count; i++)
        {
            List<double> signal = new() { inputSignals[i] };
            var neuron = Layers?[0].Neurons?[i];

            neuron?.FeedForward(signal);
        }
    }

    private void FeedForwardAllLayersAfterInput()
    {
        for (var i = 0; i < Layers?.Count; i++)
        {
            var layer = Layers[i];
            var previousLayerSignals = Layers[i - 1].GetSignals();

            foreach (var neuron in layer.Neurons!)
            {
                neuron.FeedForward(previousLayerSignals);
            }
        }
    }

    public Neuron FeedForward(List<double> inputSignals)
    {
        SendSignalsToInputNeurons(inputSignals);
        FeedForwardAllLayersAfterInput();

        var last = Layers?.Last();

        if (Topology.OutputCount is 1)
        {
            return last.Neurons[0];
        }

        return last.Neurons.OrderByDescending(n => n.Output).First();
    }

    private void CreateInputLayer()
    {
        List<Neuron> inputNeurons = new();

        for (var i = 0; i < Topology.InputCount; i++)
        {
            Neuron neuron = new(1, NeuronType.Input);
            inputNeurons.Add(neuron);
        }

        Layer inputLayer = new(inputNeurons, NeuronType.Input);
        Layers?.Add(inputLayer);
    }

    private void CreateOutputLayer()
    {
        List<Neuron> outputNeurons = new();
        var previousLayer = Layers?.Last();

        for (var i = 0; i < Topology.OutputCount; i++)
        {
            Neuron neuron = new(previousLayer!.Count, NeuronType.Output);
            outputNeurons.Add(neuron);
        }

        Layer outputLayer = new(outputNeurons, NeuronType.Output);
        Layers?.Add(outputLayer);
    }

    private void CreateHiddenLayers()
    {
        for (var i = 0; i < Topology.HiddenLayers?.Count; i++)
        {
            List<Neuron> hiddenNeurons = new();
            var previousLayer = Layers?.Last();

            for (var j = 0; j < Topology.HiddenLayers[i]; j++)
            {
                Neuron neuron = new(previousLayer!.Count, NeuronType.Hidden);
                hiddenNeurons.Add(neuron);
            }

            Layer hiddenLayer = new(hiddenNeurons, NeuronType.Hidden);
            Layers?.Add(hiddenLayer);
        }
    }
}
