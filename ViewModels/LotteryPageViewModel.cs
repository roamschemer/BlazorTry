using BlazorTry.Extends;
using BlazorTry.Models;
using BlazorTry.Pages;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTry.ViewModels {
    public class LotteryPageViewModel : BindableBase {
        public ReadOnlyReactivePropertySlim<string> Name { get; }
        public ReactiveCommand Command { get; }
        public LotteryPageViewModel(Lottery lottery) {
            Name = lottery.ObserveProperty(x => x.Name).ToReadOnlyReactivePropertySlim();
            Command = new ReactiveCommand();
            Command.Subscribe(_ => lottery.Action());
        }
    }
}
