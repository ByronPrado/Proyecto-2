using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Proyecto2.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string _valorBoleta;
    [ObservableProperty]
    private string _divisorMonto;
    [ObservableProperty]
    private string _propina;
    public MainViewModel()
    {
        _valorBoleta = "0.0";
        _divisorMonto = "1";
        _propina = "0";

    }


    [RelayCommand]
    public void MontoBoleta(string nuevoValor)
    {
        ValorBoleta = nuevoValor;
    }

    [RelayCommand]
    public void DisminuirDivisor()
    {
        if (int.TryParse(DivisorMonto, out int divisor) && divisor > 1)
        {
            divisor--;
            DivisorMonto = divisor.ToString();
        }
    }
    [RelayCommand]
    public void AumentarDivisor()
    {
        if (int.TryParse(DivisorMonto, out int divisor))
        {
            divisor++;
            DivisorMonto = divisor.ToString();
        }
    }
   

}