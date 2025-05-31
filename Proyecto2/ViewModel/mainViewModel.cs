using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Proyecto2.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private int _valorBoleta;
    [ObservableProperty]
    private int _divisorMonto;
    [ObservableProperty]
    private int _propinaPorcentaje;
    [ObservableProperty]
    private int _montoTotal;
    [ObservableProperty]
    private int _propinaMonto;
    public MainViewModel()
    {
        _valorBoleta = 0;
        _divisorMonto = 1;
        _propinaPorcentaje = 0;
        _montoTotal = 0;
        _propinaMonto = 0;

    }

    [RelayCommand]
    public void CalcularMontoTotal()
    {   
        // Esta funcion calcula el monto total de la boleta y la propina
        if (DivisorMonto > 0)
        {
            double propina = ValorBoleta * PropinaPorcentaje / 100;
            double boleta = (ValorBoleta + propina) / DivisorMonto;
            MontoTotal = (int)Math.Round(boleta, 0);
            PropinaMonto = (int)Math.Round(propina / DivisorMonto, 0);
        }
        else
        {
            MontoTotal = 0;
            PropinaMonto = 0;
        }
    }

    [RelayCommand]
    public void CantidadPersonas(string op)
    {
        if (op == "-")
        {
            if (DivisorMonto > 1)
            {
                DivisorMonto--;
                CalcularMontoTotal();
            }
        }
        else if (op == "+")
        {
            DivisorMonto++;
            CalcularMontoTotal();
        }
    }

    [RelayCommand]
    public void EditarPropina(string nuevoValor)
    {
        //esta funcion la utilizamos para los botones con propinas predefinidas
        if (int.TryParse(nuevoValor, out int porcentaje))
        {
            PropinaPorcentaje = porcentaje;
        }
        else
        {
            PropinaPorcentaje = 0; // Si no se puede convertir lo dejamos en 0
        }
        CalcularMontoTotal();
    }

    partial void OnPropinaPorcentajeChanged(int value)
    {
        // Esta funcion la utilizamos para los sliders ya que cambia directo el valor 
        CalcularMontoTotal();
    }
    partial void OnValorBoletaChanged(int value)
    {
        Console.WriteLine($"ValorBoleta tipo: {value.GetType()}");
        if (value >= 0)
        {
            ValorBoleta = value;
            CalcularMontoTotal();
        }
        else
        {
            value = 0;
            ValorBoleta = value;
            CalcularMontoTotal();
        }
    }


}