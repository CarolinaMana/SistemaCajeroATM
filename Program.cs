namespace SistemaCajeroATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Datos de negocio en memoria
            string cliente = "Carolina Bicioso", cuenta = "987654321";
            bool activa = true;
            decimal saldo = 10000.00m;

            // Interfaz de usuario
            Console.WriteLine($"ATM - CodeArt Academy\nCliente: {cliente} | Cuenta: {cuenta} | Estado: {(activa ? "Activa" : "Inactiva")}");
            Console.WriteLine("=====================================\n1. Saldo\n2. Depositar\n3. Retirar\n4. Salir\n=====================================");
            Console.Write("Seleccione opción: ");

            // Validación de entrada numérica
            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.WriteLine("\n[ERROR] Entrada inválida. Debe ser un número.");
                Finalizar(); return;
            }

            // Procesamiento de operaciones (Estructura Switch)
            switch (opcion)
            {
                case 1:
                    Console.WriteLine($"\nSaldo actual: RD${saldo:N2}");
                    break;

                case 2:
                    if (!activa) { Console.WriteLine("\n[RECHAZADO] Cuenta inactiva."); break; }
                    Console.Write("Monto a depositar: RD$");
                    if (decimal.TryParse(Console.ReadLine(), out decimal deposito) && deposito > 0)
                    {
                        saldo += deposito;
                        Console.WriteLine($"\n[ÉXITO] Depositado: RD${deposito:N2}\nNuevo Saldo: RD${saldo:N2}");
                    }
                    else Console.WriteLine("\n[RECHAZADO] Monto inválido.");
                    break;

                case 3:
                    if (!activa) { Console.WriteLine("\n[RECHAZADO] Cuenta inactiva."); break; }
                    Console.Write("Monto a retirar: RD$");
                    if (decimal.TryParse(Console.ReadLine(), out decimal retiro) && retiro > 0)
                    {
                        if (retiro > saldo) Console.WriteLine("\n[RECHAZADO] Fondos insuficientes.");
                        else
                        {
                            saldo -= retiro;
                            Console.WriteLine($"\n[ÉXITO] Retirado: RD${retiro:N2}\nNuevo Saldo: RD${saldo:N2}");
                        }
                    }
                    else Console.WriteLine("\n[RECHAZADO] Monto inválido.");
                    break;

                case 4:
                    Console.WriteLine("\nGracias por utilizar nuestros servicios.");
                    break;

                default:
                    Console.WriteLine("\n[ERROR] Opción no reconocida.");
                    break;
            }
            Finalizar();
        }

        static void Finalizar()
        {
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
