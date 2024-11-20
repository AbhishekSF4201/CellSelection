using Syncfusion.Maui.PullToRefresh;
using Syncfusion.Maui.DataGrid;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Data;
using System.Diagnostics;
using Syncfusion.Maui.DataGrid.Helper;
using Syncfusion.Maui.GridCommon.ScrollAxis;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        static int i = 0;

        public MainPage()
        {
            InitializeComponent();
           
        }
       
        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex == 1)
            {
                this.dataGrid.SelectionMode = DataGridSelectionMode.Single;
            }
            else if (selectedIndex == 2)
            {
                this.dataGrid.SelectionMode = DataGridSelectionMode.SingleDeselect;
            }
            else if (selectedIndex == 3)
            {
                this.dataGrid.SelectionMode = DataGridSelectionMode.Multiple;
            }
            else if (selectedIndex == 4)
            {
                this.dataGrid.SelectionUnit = DataGridSelectionUnit.Row;
                this.dataGrid.NavigationMode = DataGridNavigationMode.Row;
            }
            else if (selectedIndex == 5)
            {
                var stackedHeaderRow = new DataGridStackedHeaderRow();
                stackedHeaderRow.Columns.Add(new DataGridStackedColumn()
                {
                    ColumnMappingNames = "OrderID" + "," + "Customer" + "," + "CustomerID" + "," + "ShipCity",
                    Text = "Order Shipment Details",
                    MappingName = "SalesDetails",
                });
                dataGrid.StackedHeaderRows.Add(stackedHeaderRow);

                var stackedHeaderRow1 = new DataGridStackedHeaderRow();
                stackedHeaderRow1.Columns.Add(new DataGridStackedColumn()
                {
                    ColumnMappingNames = "OrderID" + "," + "Customer",
                    Text = "Order Details",
                    MappingName = "OrderDetails",
                });
                stackedHeaderRow1.Columns.Add(new DataGridStackedColumn()
                {
                    ColumnMappingNames = "CustomerID" + "," + "ShipCity",
                    Text = "Customer Details",
                    MappingName = "CustomerDetails",
                });
                this.dataGrid.StackedHeaderRows.Add(stackedHeaderRow1);
            }
            else if (selectedIndex == 6)
            {
                this.dataGrid.GroupingMode = GroupingMode.Multiple;
                dataGrid.GroupColumnDescriptions.Add(new GroupColumnDescription()
                {
                    ColumnName = "ShipCountry"
                });
                dataGrid.GroupColumnDescriptions.Add(new GroupColumnDescription()
                {
                    ColumnName = "ShipCity"
                });
            }
            else if (selectedIndex == 7)
            {
                this.dataGrid.AllowDraggingColumn = true;
            }
            else if (selectedIndex == 8)
            {
                this.dataGrid.AllowDraggingRow = true;
            }
            else if (selectedIndex == 9)
            {
                this.dataGrid.FrozenColumnCount = 2;
                this.dataGrid.FrozenRowCount = 2;
            }
            else if (selectedIndex == 10)
            {
                this.dataGrid.UnboundRows.Add(new DataGridUnboundRow() { Position = DataGridUnboundRowPosition.Top });
            }
            else if (selectedIndex == 11)
            {
                SfDataGrid dataGrid = new SfDataGrid();
                OrderInfoRepository orderInforRepo = new OrderInfoRepository();
                dataGrid.ItemsSource = orderInforRepo;

                DataGridUnboundColumn DiscountColumn = new DataGridUnboundColumn()
                {
                    MappingName = "DiscountPrice",
                    HeaderText = "SUM",
                    Expression = "Salary+100",
                    Format = "C"
                };

                this.dataGrid.Columns.Add(DiscountColumn);
            }
            else if (selectedIndex == 12)
            {
                this.dataGrid.AllowEditing = true;
            }
            else if (selectedIndex == 13)
            {
                this.dataGrid.SortingMode = DataGridSortingMode.Single;
            }
            else if (selectedIndex == 14)
            {
                this.dataGrid.AllowResizingColumns = true;
            }
            else if (selectedIndex == 15)
            {
                this.dataGrid.SelectedIndex = 2;
            }
            else if (selectedIndex == 16)
            {
                this.viewModel.OrderInfoCollection.RemoveAt(1);
            }
            else if (selectedIndex == 17)
            {
                this.viewModel.OrderInfoCollection.Insert(1, new OrderInfo("1", "Abcd", "USA", "ALPHA", "New York"));
            }
            else if (selectedIndex == 18)
            {
               
                if (this.dataGrid.DefaultColumnWidth == 200)
                {
                    this.dataGrid.DefaultColumnWidth = 0;
                }
                else
                {
                    this.dataGrid.DefaultColumnWidth = 200;
                }
            }
            else if (selectedIndex == 19)
            {
                this.dataGrid.Columns[0].Visible = !this.dataGrid.Columns[0].Visible;
            }
            else if (selectedIndex == 20)
            {
                this.dataGrid.UnboundRows.Add(new DataGridUnboundRow() { Position = DataGridUnboundRowPosition.Bottom });
            }
            else if (selectedIndex == 21)
            {
                this.dataGrid.UnboundRows.Add(new DataGridUnboundRow() { Position = DataGridUnboundRowPosition.FixedTop });
            }
            else if (selectedIndex == 22)
            {
                this.dataGrid.UnboundRows.Add(new DataGridUnboundRow() { Position = DataGridUnboundRowPosition.FixedBottom });
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewPage1());
        }
    }

    public class dataTable
    {
        public dataTable()
        {
            DataTableCollection = GetDataTable();
        }
        public DataTable DataTableCollection { get; set; }

        private DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Order ID", typeof(double));
            dataTable.Columns.Add("Customer Name", typeof(string));
            dataTable.Columns.Add("Customer ID", typeof(string));
            dataTable.Columns.Add("Country", typeof(string));
            dataTable.Rows.Add(1001, "Maria Anders", "ALFKI", "Germany");
            dataTable.Rows.Add(1002, "Ana Trujilo", "ANATR", "Mexico");
            dataTable.Rows.Add(1003, "Antonio Moreno", "ENDGY", "Mexico");
            dataTable.Rows.Add(1004, "Thomas Hardy", "ANTON", "UK");
            dataTable.Rows.Add(1005, "Christina Berglund", "BERGS", "Sweden");
            dataTable.Rows.Add(1006, "Hanna Moos", "BLAUS", "Germany");
            dataTable.Rows.Add(1007, "Frederique Citeaux", "BLONP", "France");
            dataTable.Rows.Add(1008, "Martin Sommer", "BOLID", "Spain");
            dataTable.Rows.Add(1009, "Laurence Lebihan", "BONAP", "France");
            dataTable.Rows.Add(1010, "Kathryn", "BOTTM", "Canada");
            dataTable.Rows.Add(1011, "Tamer", "XDKLF", "UK");
            dataTable.Rows.Add(1012, "Martin", "QEUDJ", "US");
            dataTable.Rows.Add(1013, "Nancy", "ALOPS", "France");
            dataTable.Rows.Add(1014, "Janet", "KSDIO", "Canada");
            dataTable.Rows.Add(1015, "Dodsworth", "AWSDE", "Canada");
            dataTable.Rows.Add(1016, "Buchanan", "CDFKL", "Germany");
            dataTable.Rows.Add(1017, "Therasa", "WSCJD", "Canada");
            dataTable.Rows.Add(1018, "Margaret", "PLSKD", "UK");
            dataTable.Rows.Add(1019, "Anto", "CCDSE", "Sweden");
            dataTable.Rows.Add(1020, "Edward", "EWUJG", "Germany");
            dataTable.Rows.Add(1021, "Anne", "AWSDK", "US");
            dataTable.Rows.Add(1022, "Callahan", "ODKLF", "UK");
            dataTable.Rows.Add(1023, "Vinet", "OEDKL", "France");
            return dataTable;
        }
    }
    public class ViewModel
    {
        static int i = 0;
        public ViewModel()
        {
            IncrementalItemsSource = new IncrementalList<OrderInfo>(LoadMoreItems) { MaxItemsCount = 1 };
        }
        private IncrementalList<OrderInfo> _incrementalItemsSource;

        public IncrementalList<OrderInfo> IncrementalItemsSource
        {
            get { return _incrementalItemsSource; }
            set { _incrementalItemsSource = value; }
        }

        async void LoadMoreItems(uint count, int baseIndex)
        {

            var _incrementalItemsSource = this.G();
            var list = GenerateOrders().Skip(baseIndex).Take(5).ToList();
            Debug.WriteLine(i++);
            IncrementalItemsSource.LoadItems(list);
           
        }
        public IncrementalList<OrderInfo> GenerateOrders()
        {
           
            _incrementalItemsSource.Add(new OrderInfo("102", "A ", "z", "AN", "Uk"));
            _incrementalItemsSource.Add(new OrderInfo("103", "b ", "x", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("104", "c ", "c", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("105", "d ", "v", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("106", "e ", "b", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("107", "f ", "n", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("108", "g ", "m", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("109", "h ", "a", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("110", "i ", "s", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("113", "q ", "d", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("123", "w ", "f", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("133", "e ", "g", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("143", "r ", "g", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("153", "t ", "h", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("163", "y ", "i", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("173", "u ", "j", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("183", "i ", "k", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("193", "o ", "ck", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("1103", "p ", "g", "A", "Hi"));
            _incrementalItemsSource.Add(new OrderInfo("1113", "s ", "l", "A", "Hi"));
           
            return _incrementalItemsSource;
        }
        public IncrementalList<OrderInfo> G()
        {
            _incrementalItemsSource.Add(new OrderInfo("1021", "Maria Andersaaaaaaaaaaaaaaaaaaaa", "Germany", "ALFKI", "Berlin"));
            _incrementalItemsSource.Add(new OrderInfo("102", "Ana Trujillo", "Mexico", "ANATR", "Mexico D.F."));
            _incrementalItemsSource.Add(new OrderInfo("103", "Ant Fuller", "Mexicoaaaaaaaaaaaaaaaaaaa", "ANTON", "Mexico D.F."));
            _incrementalItemsSource.Add(new OrderInfo("1004", "Thomas Hardy", "UK", "AROUT", "London"));
            _incrementalItemsSource.Add(new OrderInfo("1005", "Tim Adams", "Sweden", "BERGSbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb", "London"));
            _incrementalItemsSource.Add(new OrderInfo("1006", "Hanna Moos", "Germany", "BLAUS", "Mannheim"));
            _incrementalItemsSource.Add(new OrderInfo("1007", "Andrew Fuller", "France", "BLONP", "Strasbourg"));
            _incrementalItemsSource.Add(new OrderInfo("1008", "Martin King", "Spain", "BOLID", "Madridbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb"));
            _incrementalItemsSource.Add(new OrderInfo("1009", "Lenny Lin", "France", "BONAP", "Marsiella"));
            _incrementalItemsSource.Add(new OrderInfo("1010", "John Carter", "Canada", "BOTTM", "Lenny Lin"));
            _incrementalItemsSource.Add(new OrderInfo("1011", "Laura King", "UK", "AROUT", "London"));
            _incrementalItemsSource.Add(new OrderInfo("1012", "Anne Wilson", "Germany", "BLAUS", "Mannheim"));
            _incrementalItemsSource.Add(new OrderInfo("1013", "Martin King", "France", "BLONP", "Strasbourg"));
            _incrementalItemsSource.Add(new OrderInfo("1014", "Gina Irene", "UK", "AROUT", "London"));
            _incrementalItemsSource.Add(new OrderInfo("12345", "Maria ", "a", "d", "germany"));
            return _incrementalItemsSource;
        }
    }
    public class OrderInfo
    {
        private string orderID;
        private string customerID;
        private string customer;
        private string shipCity;
        private string shipCountry;
        private bool isOnline;
        private double salary;
        public string OrderID
        {
            get { return orderID; }
            set { this.orderID = value; }
        }

        public string CustomerID
        {
            get { return customerID; }
            set { this.customerID = value; }
        }

        public string ShipCountry
        {
            get { return shipCountry; }
            set { this.shipCountry = value; }
        }

        public string Customer
        {
            get { return this.customer; }
            set { this.customer = value; }
        }

        public string ShipCity
        {
            get { return shipCity; }
            set { this.shipCity = value; }
        }
        
        public double Salary
        {
            get { return salary; }
            set {  this.salary = value; }
        }
        public bool IsOnline
        {
            get { return isOnline; }
            set { this.isOnline = value; }
        }
        public OrderInfo(string orderId, string customerId, string country, string customer, string shipCity)
        {
            this.OrderID = orderId;
            this.CustomerID = customerId;
            this.Customer = customer;
            this.ShipCountry = country;
            this.ShipCity = shipCity;
            if (Convert.ToInt32(this.orderID)%2 == 0) {
                this.IsOnline = true;
            }
            else
                   this.IsOnline = false;
            this.Salary = GetSalary();
        }
        private double GetSalary()
        {
            Random random = new Random();   
            return random.NextDouble()*100;
        }
    }
    public class OrderInfoRepository
    {
        public ObservableCollection<OrderInfo> orderInfo;
        public ObservableCollection<OrderInfo> OrderInfoCollection
        {
            get { return orderInfo; }
            set { this.orderInfo = value; }
        }
      
        public OrderInfoRepository()
        {
            orderInfo = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
        }

        public void GenerateOrders()
        {

            orderInfo.Add(new OrderInfo("1001", "Alice Johnson", "USA", "ALPHA", "New York"));
            orderInfo.Add(new OrderInfo("1002", "Bob Smith", "Canada", "BRAVO", "Toronto"));
            orderInfo.Add(new OrderInfo("1003", "Charlie Brown", "UK", "CHARLIE", "London"));
            orderInfo.Add(new OrderInfo("1004", "Diana Prince", "Germany", "DELTA", "Berlin"));
            orderInfo.Add(new OrderInfo("1005", "Edward Norton", "Australia", "ECHO", "Sydney"));
            orderInfo.Add(new OrderInfo("1006", "Fiona Apple", "France", "FOXTROT", "Paris"));
            orderInfo.Add(new OrderInfo("1007", "George Clooney", "Italy", "GOLF", "Rome"));
            orderInfo.Add(new OrderInfo("1008", "Hannah Montana", "Spain", "HOTEL", "Madrid"));
            orderInfo.Add(new OrderInfo("1009", "Ian McKellen", "Netherlands", "INDIA", "Amsterdam"));
            orderInfo.Add(new OrderInfo("1010", "Jessica Jones", "Sweden", "JULIET", "Stockholm"));
            orderInfo.Add(new OrderInfo("1011", "Kevin Spacey", "Norway", "KILO", "Oslo"));
            orderInfo.Add(new OrderInfo("1012", "Laura Croft", "Denmark", "LIMA", "Copenhagen"));
            orderInfo.Add(new OrderInfo("1013", "Michael Scott", "Finland", "MIKE", "Helsinki"));
            orderInfo.Add(new OrderInfo("1014", "Nina Simone", "Ireland", "NOVEMBER", "Dublin"));
            orderInfo.Add(new OrderInfo("1015", "Oscar Isaac", "Belgium", "OSCAR", "Brussels"));
            orderInfo.Add(new OrderInfo("1016", "Pam Beesly", "Switzerland", "PAPA", "Zurich"));
            orderInfo.Add(new OrderInfo("1017", "Quentin Tarantino", "Austria", "QUEBEC", "Vienna"));
            orderInfo.Add(new OrderInfo("1018", "Rita Ora", "Portugal", "ROMEO", "Lisbon"));
            orderInfo.Add(new OrderInfo("1019", "Steve Jobs", "Greece", "SIERRA", "Athens"));
            orderInfo.Add(new OrderInfo("1020", "Tina Fey", "Russia", "TANGO", "Moscow"));
            orderInfo.Add(new OrderInfo("1021", "Uma Thurman", "Turkey", "UNIFORM", "Istanbul"));
            orderInfo.Add(new OrderInfo("1022", "Vin Diesel", "India", "VICTOR", "Mumbai"));
            orderInfo.Add(new OrderInfo("1023", "Will Smith", "Japan", "WHISKEY", "Tokyo"));
            orderInfo.Add(new OrderInfo("1024", "Xena Warrior", "South Africa", "XRAY", "Cape Town"));
            orderInfo.Add(new OrderInfo("1025", "Yara Shahidi", "Mexico", "YANKEE", "Mexico City"));
            orderInfo.Add(new OrderInfo("1026", "Zoe Saldana", "Brazil", "ZULU", "Rio de Janeiro"));
            orderInfo.Add(new OrderInfo("1027", "Adam Driver", "Chile", "ALPHA2", "Santiago"));
            orderInfo.Add(new OrderInfo("1028", "Beyoncé Knowles", "Colombia", "BRAVO2", "Bogotá"));
            orderInfo.Add(new OrderInfo("1029", "Chris Pratt", "Peru", "CHARLIE2", "Lima"));
            orderInfo.Add(new OrderInfo("1030", "Daniel Craig", "Venezuela", "DELTA2", "Caracas"));
            orderInfo.Add(new OrderInfo("1031", "Emma Watson", "Argentina", "ECHO2", "Buenos Aires"));
            orderInfo.Add(new OrderInfo("1032", "Freddie Mercury", "Paraguay", "FOXTROT2", "Asunción"));
            orderInfo.Add(new OrderInfo("1033", "Gwen Stefani", "Uruguay", "GOLF2", "Montevideo"));
            orderInfo.Add(new OrderInfo("1034", "Henry Cavill", "Ecuador", "HOTEL2", "Quito"));
            orderInfo.Add(new OrderInfo("1035", "Isla Fisher", "Bolivia", "INDIA2", "Sucre"));
            orderInfo.Add(new OrderInfo("1036", "Jake Gyllenhaal", "Honduras", "JULIET2", "Tegucigalpa"));
            orderInfo.Add(new OrderInfo("1037", "Katy Perry", "Nicaragua", "KILO2", "Managua"));
            orderInfo.Add(new OrderInfo("1038", "Leonardo DiCaprio", "Costa Rica", "LIMA2", "San José"));
            orderInfo.Add(new OrderInfo("1039", "Mila Kunis", "Panama", "MIKE2", "Panama City"));
            orderInfo.Add(new OrderInfo("1040", "Natalie Portman", "Cuba", "NOVEMBER2", "Havana"));
            orderInfo.Add(new OrderInfo("1041", "Owen Wilson", "Jamaica", "OSCAR2", "Kingston"));
            orderInfo.Add(new OrderInfo("1042", "Pablo Picasso", "Dominican Republic", "PAPA2", "Santo Domingo"));
            orderInfo.Add(new OrderInfo("1043", "Queen Latifah", "Puerto Rico", "QUEBEC2", "San Juan"));
            orderInfo.Add(new OrderInfo("1044", "Ryan Gosling", "El Salvador", "ROMEO2", "San Salvador"));
            orderInfo.Add(new OrderInfo("1045", "Scarlett Johansson", "Guatemala", "SIERRA2", "Guatemala City"));
            orderInfo.Add(new OrderInfo("1046", "Tom Hardy", "Paraguay", "TANGO2", "Asunción"));
            orderInfo.Add(new OrderInfo("1047", "Uma Thurman", "Belize", "UNIFORM2", "Belmopan"));
            orderInfo.Add(new OrderInfo("1048", "Viggo Mortensen", "Barbados", "VICTOR2", "Bridgetown"));
            orderInfo.Add(new OrderInfo("1049", "Willem Dafoe", "Bahamas", "WHISKEY2", "Nassau"));
            orderInfo.Add(new OrderInfo("1050", "Xander Cage", "Grenada", "XRAY2", "St. George's"));
            orderInfo.Add(new OrderInfo("1051", "Yvonne Strahovski", "St. Lucia", "YANKEE2", "Castries"));
            orderInfo.Add(new OrderInfo("1052", "Zach Galifianakis", "Saint Vincent and the Grenadines", "ZULU2", "Kingstown"));
            orderInfo.Add(new OrderInfo("1053", "Alicia Vikander", "Antigua and Barbuda", "ALPHA3", "Saint John's"));
            orderInfo.Add(new OrderInfo("1054", "Brad Pitt", "Saint Kitts and Nevis", "BRAVO3", "Basseterre"));
            orderInfo.Add(new OrderInfo("1055", "Catherine Zeta-Jones", "Dominica", "CHARLIE3", "Roseau"));
            orderInfo.Add(new OrderInfo("1056", "David Beckham", "Seychelles", "DELTA3", "Victoria"));
            orderInfo.Add(new OrderInfo("1057", "Eva Mendes", "Maldives", "ECHO3", "Malé"));
            orderInfo.Add(new OrderInfo("1058", "Freddie Highmore", "Fiji", "FOXTROT3", "Suva"));
            orderInfo.Add(new OrderInfo("1059", "Gillian Anderson", "Samoa", "GOLF3", "Apia"));
            orderInfo.Add(new OrderInfo("1060", "Henry Golding", "Tonga", "HOTEL3", "Nuku'alofa"));
            orderInfo.Add(new OrderInfo("1061", "Isabelle Huppert", "Kiribati", "INDIA3", "Tarawa"));
            orderInfo.Add(new OrderInfo("1062", "Jason Momoa", "Tuvalu", "JULIET3", "Funafuti"));
            orderInfo.Add(new OrderInfo("1063", "Keira Knightley", "Marshall Islands", "KILO3", "Majuro"));
            orderInfo.Add(new OrderInfo("1064", "Liam Neeson", "Palau", "LIMA3", "Ngerulmud"));
            orderInfo.Add(new OrderInfo("1065", "Maisie Williams", "Micronesia", "MIKE3", "Palikir"));
            orderInfo.Add(new OrderInfo("1066", "Naomi Watts", "Nauru", "NOVEMBER3", "Yaren"));
            orderInfo.Add(new OrderInfo("1067", "Owen Wilson", "Vanuatu", "OSCAR3", "Port Vila"));
            orderInfo.Add(new OrderInfo("1068", "Penélope Cruz", "Solomon Islands", "PAPA3", "Honiara"));
            orderInfo.Add(new OrderInfo("1069", "Queen Latifah", "Papua New Guinea", "QUEBEC3", "Port Moresby"));
            orderInfo.Add(new OrderInfo("1070", "Rami Malek", "New Zealand", "ROMEO3", "Wellington"));
            orderInfo.Add(new OrderInfo("1071", "Selena Gomez", "Australia", "SIERRA3", "Brisbane"));
            orderInfo.Add(new OrderInfo("1072", "Tobey Maguire", "Vanuatu", "TANGO3", "Port Vila"));
            orderInfo.Add(new OrderInfo("1073", "Uma Thurman", "Seychelles", "UNIFORM3", "Victoria"));
            orderInfo.Add(new OrderInfo("1074", "Vanessa Hudgens", "Maldives", "VICTOR3", "Malé"));
            orderInfo.Add(new OrderInfo("1075", "Wesley Snipes", "Bahamas", "WHISKEY3", "Nassau"));
            orderInfo.Add(new OrderInfo("1076", "Xander Cage", "Grenada", "XRAY3", "St. George's"));
            orderInfo.Add(new OrderInfo("1077", "Yara Shahidi", "St. Lucia", "YANKEE3", "Castries"));
            orderInfo.Add(new OrderInfo("1078", "Zoe Saldana", "Saint Vincent and the Grenadines", "ZULU3", "Kingstown"));
            orderInfo.Add(new OrderInfo("1079", "Anthony Mackie", "Antigua and Barbuda", "ALPHA4", "Saint John's"));
            orderInfo.Add(new OrderInfo("1080", "Benedict Cumberbatch", "Saint Kitts and Nevis", "BRAVO4", "Basseterre"));
            orderInfo.Add(new OrderInfo("1081", "Cate Blanchett", "Dominica", "CHARLIE4", "Roseau"));
            orderInfo.Add(new OrderInfo("1082", "Daniel Radcliffe", "Seychelles", "DELTA4", "Victoria"));
            orderInfo.Add(new OrderInfo("1083", "Ethan Hawke", "Maldives", "ECHO4", "Malé"));
            orderInfo.Add(new OrderInfo("1084", "Felicity Jones", "Fiji", "FOXTROT4", "Suva"));
            orderInfo.Add(new OrderInfo("1085", "Gina Rodriguez", "Samoa", "GOLF4", "Apia"));
            orderInfo.Add(new OrderInfo("1086", "Hugh Jackman", "Tonga", "HOTEL4", "Nuku'alofa"));
            orderInfo.Add(new OrderInfo("1087", "Jessica Chastain", "Kiribati", "INDIA4", "Tarawa"));
            orderInfo.Add(new OrderInfo("1088", "Kumail Nanjiani", "Tuvalu", "JULIET4", "Funafuti"));
            orderInfo.Add(new OrderInfo("1089", "Lupita Nyong'o", "Marshall Islands", "KILO4", "Majuro"));
            orderInfo.Add(new OrderInfo("1090", "Michael B. Jordan", "Palau", "LIMA4", "Ngerulmud"));
            orderInfo.Add(new OrderInfo("1091", "Natalie Dormer", "Micronesia", "MIKE4", "Palikir"));
            orderInfo.Add(new OrderInfo("1092", "Olivia Colman", "Nauru", "NOVEMBER4", "Yaren"));
            orderInfo.Add(new OrderInfo("1093", "Paul Rudd", "Vanuatu", "OSCAR4", "Port Vila"));
            orderInfo.Add(new OrderInfo("1094", "Queen Latifah", "Solomon Islands", "PAPA4", "Honiara"));
            orderInfo.Add(new OrderInfo("1095", "Ryan Reynolds", "Papua New Guinea", "QUEBEC4", "Port Moresby"));
            orderInfo.Add(new OrderInfo("1096", "Scarlett Johansson", "New Zealand", "ROMEO4", "Wellington"));
            orderInfo.Add(new OrderInfo("1097", "Tina Fey", "Australia", "SIERRA4", "Brisbane"));
            orderInfo.Add(new OrderInfo("1098", "Uma Thurman", "Vanuatu", "TANGO4", "Port Vila"));
            orderInfo.Add(new OrderInfo("1099", "Vin Diesel", "Seychelles", "UNIFORM4", "Victoria"));
            orderInfo.Add(new OrderInfo("1100", "Willem Dafoe", "Maldives", "VICTOR4", "Malé"));


        }
    }

}
