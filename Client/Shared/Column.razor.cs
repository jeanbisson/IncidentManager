using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentManager.Client.Shared
{
    public partial class Column<TItem>
    {
        [Parameter]
        public string ColumnTitle { get; set; }

        [Parameter]
        public bool filterable { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> OnSearchTextChanged { get; set; }


        //trying stuff like Radzen does with GridColumn

        [CascadingParameter]
        public TableComponent<TItem> myTable { get; set; }

        [Parameter]
        public RenderFragment Columns { get; set; }

        [CascadingParameter]
        public Column<TItem> Parent { get; set; }
    }
}
