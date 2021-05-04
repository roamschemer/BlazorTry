using BlazorTry.Extends;
using BlazorTry.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;

namespace BlazorTry.ViewModels {
    public class LotteryPageViewModel : BindableBase {
        public ReadOnlyReactivePropertySlim<string> Name { get; }
        public ReactiveCommand Action { get; }
        public ReactiveCommand<string> AddParam { get; }
        public ReadOnlyReactiveCollection<string> NameList { get; }

        public LotteryPageViewModel(Lottery lottery) {
            Name = lottery.ObserveProperty(x => x.Name).ToReadOnlyReactivePropertySlim();
            NameList = lottery.NameList.ToReadOnlyReactiveCollection();
            Action = new ReactiveCommand();
            Action.Subscribe(_ => lottery.Action());
            AddParam = new ReactiveCommand<string>();
            AddParam.Subscribe(x => lottery.Add(x));
        }
    }
}
