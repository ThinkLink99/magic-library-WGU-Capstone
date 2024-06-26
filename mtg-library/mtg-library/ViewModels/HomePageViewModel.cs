﻿using mtg_library.Data;
using mtg_library.Models;
using mtg_library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_library.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly ScryfallService scryfallService;
        private readonly IDataContext context;

        public HomePageViewModel(ScryfallService scryfallService, IDataContext context)
        {
            this.scryfallService = scryfallService;
            this.context = context;
        }

        public async Task GetActiveCollection ()
        {
            var libraries = await context.RetrieveLibrariesAsync();
            Library activeLibrary = libraries.Where(l => l.Status == "active").FirstOrDefault();

            if (activeLibrary != null)
            {
                UserPrefs.Instance.ActiveLibraryId = activeLibrary.Id;
            }
        }
    }
}
