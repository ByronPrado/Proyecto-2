using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Proyecto2.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string _valorBoleta;
    private int DivisorMonto;

    public MainViewModel()
    {
        ValorBoleta = "0.000";
        DivisorMonto = 1;
    }
    [RelayCommand]
    public void MontoBoleta()
    {
        ValorBoleta = "100000.00";
    }
    public void AumentarPersonas()
    {  
        DivisorMonto++;
        
    }
    public void DisminuirPersonas()
    {  
        if (DivisorMonto > 1)
        {
            DivisorMonto--;
        }
    }

}