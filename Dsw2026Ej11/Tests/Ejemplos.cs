using System;
using Dsw2026Ej11.Domain;
using Dsw2026Ej11.Collections;

namespace Dsw2026Ej11.Tests;


internal class Ejemplos
{
    //Agregar 3 alumnos a la lista
    //Listar por consola los alumnos
    //Buscar por nombre un alumno que exista y mostrar por consola
    //Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
    //Eliminar un alumno y listar por consola los alumnos
    //Eliminar el primer elemento de la lista y listar por consola los alumnos
    public static void EjemploList()
    {
        var l = new CasoList();


        var a1 =(new Alumno(101, "Pepe Argento", 8));
        var a2 =(new Alumno(102, "Moria Casan", 6));
        var a3 = (new Alumno(103, "Nico Sattler", 7));

        l.Add(a1); l.Add(a2); l.Add(a3);

        var listar = l.GetAll();
        Console.WriteLine("Listar todos los alumnos");
        foreach (var alumno in l.GetAll())
        {
            Console.WriteLine($"+ {alumno.Id} - {alumno.Nombre} - {alumno.Promedio}");
        }

        var alumnoExistente = l.FindByNombre("Moria Casan");
        if (alumnoExistente != null)
            Console.WriteLine($"Alumno encontrado: {alumnoExistente.Nombre}");

        var alumnoInexistente = l.FindByNombre("Maria de la Paz");
        if (alumnoInexistente == null)
            Console.WriteLine("Alumno inexistente");

        bool eliminado = l.Remove(a3);
        Console.WriteLine(eliminado ? $"Alumno eliminado" : "No se pudo eliminar");
        Console.WriteLine("Nueva lista");
        foreach (var alumno in l.GetAll())
        {
            Console.WriteLine($"+ {alumno.Id} - {alumno.Nombre} - {alumno.Promedio}");
        }

        l.RemoveAt(0);
        Console.WriteLine($"Alumno eliminado");
        Console.WriteLine("Nueva lista 2");
        foreach (var alumno in l.GetAll())
        {
            Console.WriteLine($"+ {alumno.Id} - {alumno.Nombre} - {alumno.Promedio}");
        }
    }

    //Agregar 3 alumnos al diccionario
    //Listar por consola los alumnos
    //Buscar un alumno por clave y mostrar por consola
    //Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
    //Eliminar un alumno por clave y listar por consola los alumnos
    public static void EjemploDictionary()
    {
        var d = new CasoDictionary();

        d.Add(new Alumno(1, "Pepe Argento", 8));
        d.Add(new Alumno(2, "Moria Casan", 6));
        d.Add(new Alumno(3, "Nico Sattler", 7));

        var listar = d.GetAll();
        Console.WriteLine("Listar todos los alumnos");
        foreach (var alumno in d.GetAll().Values)
        {
            Console.WriteLine($"+ {alumno.Id} - {alumno.Nombre} - {alumno.Promedio}");
        }

        var alumnoExistente = d.Find(1);
        if (alumnoExistente != null)
            Console.WriteLine($"Alumno encontrado: {alumnoExistente.Nombre}");

        var alumnoInexistente = d.Find(999);
        if (alumnoInexistente == null)
            Console.WriteLine($"Alumno {alumnoInexistente} inexistente");

        bool eliminado = d.Remove(2);
        Console.WriteLine(eliminado ? $"Alumno eliminado" : "No se pudo eliminar");
        Console.WriteLine("Nueva lista");
        foreach (var alumno in d.GetAll().Values)
        {
            Console.WriteLine($"+ {alumno.Id} - {alumno.Nombre} - {alumno.Promedio}");
        }

    }

    //Realizar una llamada a cada método definido en CasoLinq y mostar por consola según corresponda
    public static void EjemploLinq()
    {
        var linq = new CasoLinq();

        Console.WriteLine($"Primer libro: { linq.GetPrimero()?.Titulo}");

        Console.WriteLine($"Ultimo libro: {linq.GetUltimo()?.Titulo}");

        Console.WriteLine($"Precio Total: {linq.GetTotalPrecios():F2}");

        Console.WriteLine($"Promedio: {linq.GetPromedioPrecios():F2}");

        Console.WriteLine("Libros con Id > 15:");
        foreach (var lId in linq.GetListById())
            Console.WriteLine($"+ {lId.Id} - {lId.Titulo}");
        
        Console.WriteLine("Libros con formato moneda:");
        foreach (var lMoneda in linq.GetLibros())
            Console.WriteLine("   " + lMoneda);
        
        Console.WriteLine("Mayor Precio: " + linq.GetMayorPrecio()?.Titulo);
        Console.WriteLine("Menor precio: " + linq.GetMenorPrecio()?.Titulo);
        
        Console.WriteLine("Libros con precio mayor al promedio:");
        foreach (var lMayorProm in linq.GetMayorPromedio())
            Console.WriteLine($"   {lMayorProm.Titulo} - {lMayorProm.Precio:C}");
        
        Console.WriteLine("Libros ordenados por título descendente:");
        foreach (var lDes in linq.GetTituloDesc())
            Console.WriteLine("   " + lDes.Titulo);
        
    }
}

