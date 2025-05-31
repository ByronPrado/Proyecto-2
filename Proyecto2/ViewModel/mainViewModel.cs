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
        if (DivisorMonto > 0)
        {
            double propina = ValorBoleta * PropinaPorcentaje / 100;
            double boleta = (ValorBoleta + propina) / DivisorMonto;
            MontoTotal = (int)Math.Round(boleta, 0);
            PropinaMonto = (int)Math.Round(propina/DivisorMonto, 0);
        }
        else
        {
            MontoTotal = 0;
            PropinaMonto = 0;
        }
    }
    [RelayCommand]
    public void MontoBoleta(int nuevoValor)
    {
        if (nuevoValor >= 0)
        {
            ValorBoleta = nuevoValor;
            CalcularMontoTotal();
        }
        else
        {
            nuevoValor = 0;
            ValorBoleta = nuevoValor;
        }
    }

    [RelayCommand]
    public void DisminuirDivisor()
    {
        if (DivisorMonto > 1)
        {
            DivisorMonto--;
            CalcularMontoTotal();
        }
    }
    [RelayCommand]
    public void AumentarDivisor()
    {
        DivisorMonto++;
        CalcularMontoTotal();        
    }

    [RelayCommand]
    public void EditarPropina(int nuevoValor)
    {
        PropinaPorcentaje = nuevoValor;
        CalcularMontoTotal();
    }


}