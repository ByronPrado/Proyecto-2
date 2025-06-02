using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Proyecto2.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private int _valorBoleta;
    [ObservableProperty]
    private int _valorBoletaEntry;
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
        _valorBoletaEntry = 0;
        _divisorMonto = 1;
        _propinaPorcentaje = 0;
        _montoTotal = 0;
        _propinaMonto = 0;

    }

    [RelayCommand]
    public void CalcularMontoTotal()
    {
        if (DivisorMonto > 0)
        {
            double propina = ValorBoletaEntry * PropinaPorcentaje / 100;
            double boleta = (ValorBoletaEntry + propina) / DivisorMonto;
            double subtotal = ValorBoletaEntry / DivisorMonto;
            MontoTotal = (int)Math.Round(boleta, 0);
            PropinaMonto = (int)Math.Round(propina / DivisorMonto, 0);
            ValorBoleta = (int)Math.Round(subtotal, 0);
        }
        else
        {
            MontoTotal = 0;
            PropinaMonto = 0;
            ValorBoleta = 0;
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
        if (int.TryParse(nuevoValor, out int porcentaje))
        {
            PropinaPorcentaje = porcentaje;
        }
        else
        {
            PropinaPorcentaje = 0;
        }
        CalcularMontoTotal();
    }

    partial void OnPropinaPorcentajeChanged(int value)
    {
        CalcularMontoTotal();
    }
    partial void OnValorBoletaEntryChanged(int value)
    {
        Console.WriteLine($"ValorBoletaEntry tipo: {value.GetType()}");
        if (value >= 0)
        {
            ValorBoletaEntry = value;
            CalcularMontoTotal();
        }
        else
        {
            value = 0;
            ValorBoletaEntry = value;
            CalcularMontoTotal();
        }
    }


}