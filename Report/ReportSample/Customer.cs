using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ReportSample
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }

    public class CustomerCollection : List<Customer>
    {
        public CustomerCollection()
        {
            this.Add(new Customer { CustomerId = "ALFKI", CompanyName = "Alfreds Futterkiste", ContactName = "Maria Anders", ContactTitle = "Sales Representative", Address = "Obere Str. 57", City = "Berlin" });
            this.Add(new Customer { CustomerId = "ANATR", CompanyName = "Ana Trujillo Emparedados y helados", ContactName = "Ana Trujillo", ContactTitle = "Owner", Address = "Avda. de la Constitución 2222", City = "México D.F." });
            this.Add(new Customer { CustomerId = "ANTON", CompanyName = "Antonio Moreno Taquería", ContactName = "Antonio Moreno", ContactTitle = "Owner", Address = "Mataderos  2312", City = "México D.F." });
            this.Add(new Customer { CustomerId = "AROUT", CompanyName = "Around the Horn", ContactName = "Thomas Hardy", ContactTitle = "Sales Representative", Address = "120 Hanover Sq.", City = "London" });
            this.Add(new Customer { CustomerId = "BERGS", CompanyName = "Berglunds snabbköp", ContactName = "Christina Berglund", ContactTitle = "Order Administrator", Address = "Berguvsvägen  8", City = "Luleå" });
            this.Add(new Customer { CustomerId = "BLAUS", CompanyName = "Blauer See Delikatessen", ContactName = "Hanna Moos", ContactTitle = "Sales Representative", Address = "Forsterstr. 57", City = "Mannheim" });
            this.Add(new Customer { CustomerId = "BLONP", CompanyName = "Blondesddsl père et fils", ContactName = "Frédérique Citeaux", ContactTitle = "Marketing Manager", Address = "24, place Kléber", City = "Strasbourg" });
            this.Add(new Customer { CustomerId = "BOLID", CompanyName = "Bólido Comidas preparadas", ContactName = "Martín Sommer", ContactTitle = "Owner", Address = "C/ Araquil, 67", City = "Madrid" });
            this.Add(new Customer { CustomerId = "BONAP", CompanyName = "Bon app'", ContactName = "Laurence Lebihan", ContactTitle = "Owner", Address = "12, rue des Bouchers", City = "Marseille" });
            this.Add(new Customer { CustomerId = "BOTTM", CompanyName = "Bottom-Dollar Markets", ContactName = "Elizabeth Lincoln", ContactTitle = "Accounting Manager", Address = "23 Tsawassen Blvd.", City = "Tsawassen" });
            this.Add(new Customer { CustomerId = "BSBEV", CompanyName = "B's Beverages", ContactName = "Victoria Ashworth", ContactTitle = "Sales Representative", Address = "Fauntleroy Circus", City = "London" });
            this.Add(new Customer { CustomerId = "CACTU", CompanyName = "Cactus Comidas para llevar", ContactName = "Patricio Simpson", ContactTitle = "Sales Agent", Address = "Cerrito 333", City = "Buenos Aires" });
            this.Add(new Customer { CustomerId = "CENTC", CompanyName = "Centro comercial Moctezuma", ContactName = "Francisco Chang", ContactTitle = "Marketing Manager", Address = "Sierras de Granada 9993", City = "México D.F." });
            this.Add(new Customer { CustomerId = "CHOPS", CompanyName = "Chop-suey Chinese", ContactName = "Yang Wang", ContactTitle = "Owner", Address = "Hauptstr. 29", City = "Bern" });
            this.Add(new Customer { CustomerId = "COMMI", CompanyName = "Comércio Mineiro", ContactName = "Pedro Afonso", ContactTitle = "Sales Associate", Address = "Av. dos Lusíadas, 23", City = "Sao Paulo" });
            this.Add(new Customer { CustomerId = "CONSH", CompanyName = "Consolidated Holdings", ContactName = "Elizabeth Brown", ContactTitle = "Sales Representative", Address = "Berkeley Gardens 12  Brewery", City = "London" });
            this.Add(new Customer { CustomerId = "DRACD", CompanyName = "Drachenblut Delikatessen", ContactName = "Sven Ottlieb", ContactTitle = "Order Administrator", Address = "Walserweg 21", City = "Aachen" });
            this.Add(new Customer { CustomerId = "DUMON", CompanyName = "Du monde entier", ContactName = "Janine Labrune", ContactTitle = "Owner", Address = "67, rue des Cinquante Otages", City = "Nantes" });
            this.Add(new Customer { CustomerId = "EASTC", CompanyName = "Eastern Connection", ContactName = "Ann Devon", ContactTitle = "Sales Agent", Address = "35 King George", City = "London" });
            this.Add(new Customer { CustomerId = "ERNSH", CompanyName = "Ernst Handel", ContactName = "Roland Mendel", ContactTitle = "Sales Manager", Address = "Kirchgasse 6", City = "Graz" });
            this.Add(new Customer { CustomerId = "FAMIA", CompanyName = "Familia Arquibaldo", ContactName = "Aria Cruz", ContactTitle = "Marketing Assistant", Address = "Rua Orós, 92", City = "Sao Paulo" });
            this.Add(new Customer { CustomerId = "FISSA", CompanyName = "FISSA Fabrica Inter. Salchichas S.A.", ContactName = "Diego Roel", ContactTitle = "Accounting Manager", Address = "C/ Moralzarzal, 86", City = "Madrid" });
            this.Add(new Customer { CustomerId = "FOLIG", CompanyName = "Folies gourmandes", ContactName = "Martine Rancé", ContactTitle = "Assistant Sales Agent", Address = "184, chaussée de Tournai", City = "Lille" });
            this.Add(new Customer { CustomerId = "FOLKO", CompanyName = "Folk och fä HB", ContactName = "Maria Larsson", ContactTitle = "Owner", Address = "Åkergatan 24", City = "Bräcke" });
            this.Add(new Customer { CustomerId = "FRANK", CompanyName = "Frankenversand", ContactName = "Peter Franken", ContactTitle = "Marketing Manager", Address = "Berliner Platz 43", City = "München" });
            this.Add(new Customer { CustomerId = "FRANR", CompanyName = "France restauration", ContactName = "Carine Schmitt", ContactTitle = "Marketing Manager", Address = "54, rue Royale", City = "Nantes" });
            this.Add(new Customer { CustomerId = "FRANS", CompanyName = "Franchi S.p.A.", ContactName = "Paolo Accorti", ContactTitle = "Sales Representative", Address = "Via Monte Bianco 34", City = "Torino" });
            this.Add(new Customer { CustomerId = "FURIB", CompanyName = "Furia Bacalhau e Frutos do Mar", ContactName = "Lino Rodriguez", ContactTitle = "Sales Manager", Address = "Jardim das rosas n. 32", City = "Lisboa" });
            this.Add(new Customer { CustomerId = "GALED", CompanyName = "Galería del gastrónomo", ContactName = "Eduardo Saavedra", ContactTitle = "Marketing Manager", Address = "Rambla de Cataluña, 23", City = "Barcelona" });
            this.Add(new Customer { CustomerId = "GODOS", CompanyName = "Godos Cocina Típica", ContactName = "José Pedro Freyre", ContactTitle = "Sales Manager", Address = "C/ Romero, 33", City = "Sevilla" });
            this.Add(new Customer { CustomerId = "GOURL", CompanyName = "Gourmet Lanchonetes", ContactName = "André Fonseca", ContactTitle = "Sales Associate", Address = "Av. Brasil, 442", City = "Campinas" });
            this.Add(new Customer { CustomerId = "GREAL", CompanyName = "Great Lakes Food Market", ContactName = "Howard Snyder", ContactTitle = "Marketing Manager", Address = "2732 Baker Blvd.", City = "Eugene" });
            this.Add(new Customer { CustomerId = "GROSR", CompanyName = "GROSELLA-Restaurante", ContactName = "Manuel Pereira", ContactTitle = "Owner", Address = "5ª Ave. Los Palos Grandes", City = "Caracas" });
            this.Add(new Customer { CustomerId = "HANAR", CompanyName = "Hanari Carnes", ContactName = "Mario Pontes", ContactTitle = "Accounting Manager", Address = "Rua do Paço, 67", City = "Rio de Janeiro" });
            this.Add(new Customer { CustomerId = "HILAA", CompanyName = "HILARION-Abastos", ContactName = "Carlos Hernández", ContactTitle = "Sales Representative", Address = "Carrera 22 con Ave. Carlos Soublette #8-35", City = "San Cristóbal" });
            this.Add(new Customer { CustomerId = "HUNGC", CompanyName = "Hungry Coyote Import Store", ContactName = "Yoshi Latimer", ContactTitle = "Sales Representative", Address = "City Center Plaza 516 Main St.", City = "Elgin" });
            this.Add(new Customer { CustomerId = "HUNGO", CompanyName = "Hungry Owl All-Night Grocers", ContactName = "Patricia McKenna", ContactTitle = "Sales Associate", Address = "8 Johnstown Road", City = "Cork" });
            this.Add(new Customer { CustomerId = "ISLAT", CompanyName = "Island Trading", ContactName = "Helen Bennett", ContactTitle = "Marketing Manager", Address = "Garden House Crowther Way", City = "Cowes" });
            this.Add(new Customer { CustomerId = "KOENE", CompanyName = "Königlich Essen", ContactName = "Philip Cramer", ContactTitle = "Sales Associate", Address = "Maubelstr. 90", City = "Brandenburg" });
            this.Add(new Customer { CustomerId = "LACOR", CompanyName = "La corne d'abondance", ContactName = "Daniel Tonini", ContactTitle = "Sales Representative", Address = "67, avenue de l'Europe", City = "Versailles" });
            this.Add(new Customer { CustomerId = "LAMAI", CompanyName = "La maison d'Asie", ContactName = "Annette Roulet", ContactTitle = "Sales Manager", Address = "1 rue Alsace-Lorraine", City = "Toulouse" });
            this.Add(new Customer { CustomerId = "LAUGB", CompanyName = "Laughing Bacchus Wine Cellars", ContactName = "Yoshi Tannamuri", ContactTitle = "Marketing Assistant", Address = "1900 Oak St.", City = "Vancouver" });
            this.Add(new Customer { CustomerId = "LAZYK", CompanyName = "Lazy K Kountry Store", ContactName = "John Steel", ContactTitle = "Marketing Manager", Address = "12 Orchestra Terrace", City = "Walla Walla" });
            this.Add(new Customer { CustomerId = "LEHMS", CompanyName = "Lehmanns Marktstand", ContactName = "Renate Messner", ContactTitle = "Sales Representative", Address = "Magazinweg 7", City = "Frankfurt a.M." });
            this.Add(new Customer { CustomerId = "LETSS", CompanyName = "Let's Stop N Shop", ContactName = "Jaime Yorres", ContactTitle = "Owner", Address = "87 Polk St. Suite 5", City = "San Francisco" });
            this.Add(new Customer { CustomerId = "LILAS", CompanyName = "LILA-Supermercado", ContactName = "Carlos González", ContactTitle = "Accounting Manager", Address = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo", City = "Barquisimeto" });
            this.Add(new Customer { CustomerId = "LINOD", CompanyName = "LINO-Delicateses", ContactName = "Felipe Izquierdo", ContactTitle = "Owner", Address = "Ave. 5 de Mayo Porlamar", City = "I. de Margarita" });
            this.Add(new Customer { CustomerId = "LONEP", CompanyName = "Lonesome Pine Restaurant", ContactName = "Fran Wilson", ContactTitle = "Sales Manager", Address = "89 Chiaroscuro Rd.", City = "Portland" });
            this.Add(new Customer { CustomerId = "MAGAA", CompanyName = "Magazzini Alimentari Riuniti", ContactName = "Giovanni Rovelli", ContactTitle = "Marketing Manager", Address = "Via Ludovico il Moro 22", City = "Bergamo" });
            this.Add(new Customer { CustomerId = "MAISD", CompanyName = "Maison Dewey", ContactName = "Catherine Dewey", ContactTitle = "Sales Agent", Address = "Rue Joseph-Bens 532", City = "Bruxelles" });
            this.Add(new Customer { CustomerId = "MEREP", CompanyName = "Mère Paillarde", ContactName = "Jean Fresnière", ContactTitle = "Marketing Assistant", Address = "43 rue St. Laurent", City = "Montréal" });
            this.Add(new Customer { CustomerId = "MORGK", CompanyName = "Morgenstern Gesundkost", ContactName = "Alexander Feuer", ContactTitle = "Marketing Assistant", Address = "Heerstr. 22", City = "Leipzig" });
            this.Add(new Customer { CustomerId = "NORTS", CompanyName = "North/South", ContactName = "Simon Crowther", ContactTitle = "Sales Associate", Address = "South House 300 Queensbridge", City = "London" });
            this.Add(new Customer { CustomerId = "OCEAN", CompanyName = "Océano Atlántico Ltda.", ContactName = "Yvonne Moncada", ContactTitle = "Sales Agent", Address = "Ing. Gustavo Moncada 8585 Piso 20-A", City = "Buenos Aires" });
            this.Add(new Customer { CustomerId = "OLDWO", CompanyName = "Old World Delicatessen", ContactName = "Rene Phillips", ContactTitle = "Sales Representative", Address = "2743 Bering St.", City = "Anchorage" });
            this.Add(new Customer { CustomerId = "OTTIK", CompanyName = "Ottilies Käseladen", ContactName = "Henriette Pfalzheim", ContactTitle = "Owner", Address = "Mehrheimerstr. 369", City = "Köln" });
            this.Add(new Customer { CustomerId = "PARIS", CompanyName = "Paris spécialités", ContactName = "Marie Bertrand", ContactTitle = "Owner", Address = "265, boulevard Charonne", City = "Paris" });
            this.Add(new Customer { CustomerId = "PERIC", CompanyName = "Pericles Comidas clásicas", ContactName = "Guillermo Fernández", ContactTitle = "Sales Representative", Address = "Calle Dr. Jorge Cash 321", City = "México D.F." });
            this.Add(new Customer { CustomerId = "PICCO", CompanyName = "Piccolo und mehr", ContactName = "Georg Pipps", ContactTitle = "Sales Manager", Address = "Geislweg 14", City = "Salzburg" });
            this.Add(new Customer { CustomerId = "PRINI", CompanyName = "Princesa Isabel Vinhos", ContactName = "Isabel de Castro", ContactTitle = "Sales Representative", Address = "Estrada da saúde n. 58", City = "Lisboa" });
            this.Add(new Customer { CustomerId = "QUEDE", CompanyName = "Que Delícia", ContactName = "Bernardo Batista", ContactTitle = "Accounting Manager", Address = "Rua da Panificadora, 12", City = "Rio de Janeiro" });
            this.Add(new Customer { CustomerId = "QUEEN", CompanyName = "Queen Cozinha", ContactName = "Lúcia Carvalho", ContactTitle = "Marketing Assistant", Address = "Alameda dos Canàrios, 891", City = "Sao Paulo" });
            this.Add(new Customer { CustomerId = "QUICK", CompanyName = "QUICK-Stop", ContactName = "Horst Kloss", ContactTitle = "Accounting Manager", Address = "Taucherstraße 10", City = "Cunewalde" });
            this.Add(new Customer { CustomerId = "RANCH", CompanyName = "Rancho grande", ContactName = "Sergio Gutiérrez", ContactTitle = "Sales Representative", Address = "Av. del Libertador 900", City = "Buenos Aires" });
            this.Add(new Customer { CustomerId = "RATTC", CompanyName = "Rattlesnake Canyon Grocery", ContactName = "Paula Wilson", ContactTitle = "Assistant Sales Representative", Address = "2817 Milton Dr.", City = "Albuquerque" });
            this.Add(new Customer { CustomerId = "REGGC", CompanyName = "Reggiani Caseifici", ContactName = "Maurizio Moroni", ContactTitle = "Sales Associate", Address = "Strada Provinciale 124", City = "Reggio Emilia" });
            this.Add(new Customer { CustomerId = "RICAR", CompanyName = "Ricardo Adocicados", ContactName = "Janete Limeira", ContactTitle = "Assistant Sales Agent", Address = "Av. Copacabana, 267", City = "Rio de Janeiro" });
            this.Add(new Customer { CustomerId = "RICSU", CompanyName = "Richter Supermarkt", ContactName = "Michael Holz", ContactTitle = "Sales Manager", Address = "Grenzacherweg 237", City = "Genève" });
            this.Add(new Customer { CustomerId = "ROMEY", CompanyName = "Romero y tomillo", ContactName = "Alejandra Camino", ContactTitle = "Accounting Manager", Address = "Gran Vía, 1", City = "Madrid" });
            this.Add(new Customer { CustomerId = "SANTG", CompanyName = "Santé Gourmet", ContactName = "Jonas Bergulfsen", ContactTitle = "Owner", Address = "Erling Skakkes gate 78", City = "Stavern" });
            this.Add(new Customer { CustomerId = "SAVEA", CompanyName = "Save-a-lot Markets", ContactName = "Jose Pavarotti", ContactTitle = "Sales Representative", Address = "187 Suffolk Ln.", City = "Boise" });
            this.Add(new Customer { CustomerId = "SEVES", CompanyName = "Seven Seas Imports", ContactName = "Hari Kumar", ContactTitle = "Sales Manager", Address = "90 Wadhurst Rd.", City = "London" });
            this.Add(new Customer { CustomerId = "SIMOB", CompanyName = "Simons bistro", ContactName = "Jytte Petersen", ContactTitle = "Owner", Address = "Vinbæltet 34", City = "Kobenhavn" });
            this.Add(new Customer { CustomerId = "SPECD", CompanyName = "Spécialités du monde", ContactName = "Dominique Perrier", ContactTitle = "Marketing Manager", Address = "25, rue Lauriston", City = "Paris" });
            this.Add(new Customer { CustomerId = "SPLIR", CompanyName = "Split Rail Beer & Ale", ContactName = "Art Braunschweiger", ContactTitle = "Sales Manager", Address = "P.O. Box 555", City = "Lander" });
            this.Add(new Customer { CustomerId = "SUPRD", CompanyName = "Suprêmes délices", ContactName = "Pascale Cartrain", ContactTitle = "Accounting Manager", Address = "Boulevard Tirou, 255", City = "Charleroi" });
            this.Add(new Customer { CustomerId = "THEBI", CompanyName = "The Big Cheese", ContactName = "Liz Nixon", ContactTitle = "Marketing Manager", Address = "89 Jefferson Way Suite 2", City = "Portland" });
            this.Add(new Customer { CustomerId = "THECR", CompanyName = "The Cracker Box", ContactName = "Liu Wong", ContactTitle = "Marketing Assistant", Address = "55 Grizzly Peak Rd.", City = "Butte" });
            this.Add(new Customer { CustomerId = "TOMSP", CompanyName = "Toms Spezialitäten", ContactName = "Karin Josephs", ContactTitle = "Marketing Manager", Address = "Luisenstr. 48", City = "Münster" });
            this.Add(new Customer { CustomerId = "TORTU", CompanyName = "Tortuga Restaurante", ContactName = "Miguel Angel Paolino", ContactTitle = "Owner", Address = "Avda. Azteca 123", City = "México D.F." });
            this.Add(new Customer { CustomerId = "TRADH", CompanyName = "Tradição Hipermercados", ContactName = "Anabela Domingues", ContactTitle = "Sales Representative", Address = "Av. Inês de Castro, 414", City = "Sao Paulo" });
            this.Add(new Customer { CustomerId = "TRAIH", CompanyName = "Trail's Head Gourmet Provisioners", ContactName = "Helvetius Nagy", ContactTitle = "Sales Associate", Address = "722 DaVinci Blvd.", City = "Kirkland" });
            this.Add(new Customer { CustomerId = "VAFFE", CompanyName = "Vaffeljernet", ContactName = "Palle Ibsen", ContactTitle = "Sales Manager", Address = "Smagsloget 45", City = "Århus" });
            this.Add(new Customer { CustomerId = "VICTE", CompanyName = "Victuailles en stock", ContactName = "Mary Saveley", ContactTitle = "Sales Agent", Address = "2, rue du Commerce", City = "Lyon" });
            this.Add(new Customer { CustomerId = "VINET", CompanyName = "Vins et alcools Chevalier", ContactName = "Paul Henriot", ContactTitle = "Accounting Manager", Address = "59 rue de l'Abbaye", City = "Reims" });
            this.Add(new Customer { CustomerId = "WANDK", CompanyName = "Die Wandernde Kuh", ContactName = "Rita Müller", ContactTitle = "Sales Representative", Address = "Adenauerallee 900", City = "Stuttgart" });
            this.Add(new Customer { CustomerId = "WARTH", CompanyName = "Wartian Herkku", ContactName = "Pirkko Koskitalo", ContactTitle = "Accounting Manager", Address = "Torikatu 38", City = "Oulu" });
            this.Add(new Customer { CustomerId = "WELLI", CompanyName = "Wellington Importadora", ContactName = "Paula Parente", ContactTitle = "Sales Manager", Address = "Rua do Mercado, 12", City = "Resende" });
            this.Add(new Customer { CustomerId = "WHITC", CompanyName = "White Clover Markets", ContactName = "Karl Jablonski", ContactTitle = "Owner", Address = "305 - 14th Ave. S. Suite 3B", City = "Seattle" });
            this.Add(new Customer { CustomerId = "WILMK", CompanyName = "Wilman Kala", ContactName = "Matti Karttunen", ContactTitle = "Owner/Marketing Assistant", Address = "Keskuskatu 45", City = "Helsinki" });
            this.Add(new Customer { CustomerId = "WOLZA", CompanyName = "Wolski  Zajazd", ContactName = "Zbyszek Piestrzeniewicz", ContactTitle = "Owner", Address = "ul. Filtrowa 68", City = "Warszawa" });
        }
    }
}
