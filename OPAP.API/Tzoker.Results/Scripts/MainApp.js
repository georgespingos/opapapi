function AppViewModel() {
    this.drawType = ko.observable();
    this.drawResultType = ko.observable();
    this.drawId = ko.observable();
    this.apiCallUrl = ko.computed(function () {
        return "http://opapi.apphb.com/api/" + this.drawType() + "/" + this.drawResultType() + "/" + this.drawId();
    }, this);
}

// Activates knockout.js
ko.applyBindings(new AppViewModel());