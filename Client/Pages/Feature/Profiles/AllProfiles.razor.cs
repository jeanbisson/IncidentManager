using IncidentManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Util;
using ChartJs.Blazor.Common;

namespace IncidentManager.Client.Pages.Feature.Profiles
{
    public partial class AllProfiles
    {
        private List<Profile> profiles;
        private PieConfig _config;

        protected override async Task OnInitializedAsync()
        {
            profiles = await Http.GetFromJsonAsync<List<Profile>>("/api/Profile");

            _config = new PieConfig
            {
                Options = new PieOptions
                {
                    Responsive = true,
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "ChartJs.Blazor Pie Chart"
                    }
                }
            };

            foreach (string color in new[] { "Red", "Yellow", "Green", "Blue" })
            {
                _config.Data.Labels.Add(color);
            }

            PieDataset<int> dataset = new PieDataset<int>(new[] { 6, 5, 3, 7 })
            {
                BackgroundColor = new[]
                {
            ColorUtil.ColorHexString(255, 99, 132), // Slice 1 aka "Red"
            ColorUtil.ColorHexString(255, 205, 86), // Slice 2 aka "Yellow"
            ColorUtil.ColorHexString(75, 192, 192), // Slice 3 aka "Green"
            ColorUtil.ColorHexString(54, 162, 235), // Slice 4 aka "Blue"
        }
            };

            _config.Data.Datasets.Add(dataset);
        }

        private async Task DeleteProfile(Profile profile)
        {
            await Http.DeleteAsync($"/api/Profile/{profile.Id}");
            profiles.Remove(profile);
            StateHasChanged();
        }

        private void EditProfile(int profileId)
        {
            Navigation.NavigateTo("/editprofile/" + profileId);
        }

        private void CreateProfile()
        {
            Navigation.NavigateTo("/createprofile");
        }
    }
}
