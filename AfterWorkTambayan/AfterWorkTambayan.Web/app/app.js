$(document).ready(function () {
    $('#collapseThree').on('show', function () {
        if (angularJSFix) {
            loadingIndicator();            
            window.location.href = "/Restaurant?angularJSFix=Yes&restaurantId=" + angularJSFixRestaurant;
        }
    })
});

var app = angular.module('app', []);

function FoodsAndServicesCtrl($scope) {
    $scope.data = {
        editFlag: false,
        master: "",
        selectedAvailable: { foodType: "", availableServices: [] },
        foods: [
                {
                    type: "Kapampangan",
                    selected: true,
                    available: [
                        { service: "Delivery", action: false, test: true, public: true, internal: false },
                        { service: "Pick up", action: false, test: true, public: true, internal: false },
                        { service: "Dine in", action: false, test: true, public: true, internal: false },
                        { service: "Reservation", action: false, test: true, public: true, internal: false },
                        { service: "Waiters", action: false, test: true, public: true, internal: false }
                    ]
                },
                {
                    type: "Visayan",
                    selected: false,
                    available: [
                        { service: "Delivery", action: false, test: true, public: true, internal: false },
                        { service: "Pick up", action: false, test: true, public: true, internal: false },
                        { service: "Dine in", action: false, test: true, public: true, internal: false },
                        { service: "Reservation", action: false, test: true, public: true, internal: false },
                        { service: "Waiters", action: false, test: true, public: true, internal: false }
                    ]
                },
                {
                    type: "Tagalog",
                    selected: false,
                    available: [
                        { service: "Delivery", action: true, test: false, public: false, internal: true },
                        { service: "Pick up", action: true, test: false, public: false, internal: true },
                        { service: "Dine in", action: true, test: false, public: false, internal: true },
                        { service: "Reservation", action: true, test: false, public: false, internal: true },
                        { service: "Waiters", action: true, test: false, public: false, internal: true }
                    ]
                },
                {
                    type: "Kastila",
                    selected: false,
                    available: [
                        { service: "Delivery", action: false, test: true, public: true, internal: false },
                        { service: "Pick up", action: false, test: true, public: true, internal: false },
                        { service: "Dine in", action: false, test: true, public: true, internal: false },
                        { service: "Reservation", action: false, test: true, public: true, internal: false },
                        { service: "Waiters", action: false, test: true, public: true, internal: false }
                    ]
                },
                {
                    type: "Tsekwa",
                    selected: false,
                    available: [
                        { service: "Delivery", action: true, test: false, public: false, internal: true },
                        { service: "Pick up", action: true, test: false, public: false, internal: true },
                        { service: "Dine in", action: true, test: false, public: false, internal: true },
                        { service: "Reservation", action: true, test: false, public: false, internal: true },
                        { service: "Waiters", action: true, test: false, public: false, internal: true }
                    ]
                },
                {
                    type: "Ilocano",
                    selected: false,
                    available: [
                        { service: "Delivery", action: false, test: true, public: true, internal: false },
                        { service: "Pick up", action: false, test: true, public: true, internal: false },
                        { service: "Dine in", action: false, test: true, public: true, internal: false },
                        { service: "Reservation", action: false, test: true, public: true, internal: false },
                        { service: "Waiters", action: false, test: true, public: true, internal: false }
                    ]
                },
                {
                    type: "Bicolano",
                    selected: false,
                    available: [
                        { service: "Delivery", action: true, test: false, public: false, internal: true },
                        { service: "Pick up", action: true, test: false, public: false, internal: true },
                        { service: "Dine in", action: true, test: false, public: false, internal: true },
                        { service: "Reservation", action: true, test: false, public: false, internal: true },
                        { service: "Waiters", action: true, test: false, public: false, internal: true }
                    ]
                }
            ]
    };

    $scope.addNewItem = function (addText) {
        if (addText) {
            $scope.data.foods.push(
                    {
                        type: addText,
                        selected: false,
                        available: [
                        { service: "Delivery", action: false, test: false, public: false, internal: false },
                        { service: "Pick up", action: false, test: false, public: false, internal: false },
                        { service: "Dine in", action: false, test: false, public: false, internal: false },
                        { service: "Reservation", action: false, test: false, public: false, internal: false },
                        { service: "Waiters", action: false, test: false, public: false, internal: false }
                    ]
                    }
                );
            $scope.addText = "";
        }
    };

    $scope.deleteFoodType = function (food) {
        angular.forEach($scope.data.foods, function (item, index) {
            if (item.type === food.type) {
                //console.log("item.type === typeOfFood = " + item.type);
                $scope.data.foods.splice(index, 1);
                if (item.type === $scope.data.selectedAvailable.foodType) {
                    $scope.data.selectedAvailable = {};
                }
            }
        });
    };

    $scope.toggleEditMode = function (food) {
        if (!$scope.data.editFlag) {
            $scope.data.master = food.type;
            food.editMode = !food.editMode;
            $scope.data.editFlag = true;
        }
    };

    $scope.updateFoodType = function (food) {
        food.editMode = !food.editMode;
        if (food.selected) {
            $scope.data.selectedAvailable.foodType = food.type;
            $scope.data.master = "";
        }
        $scope.data.editFlag = false;
    };

    $scope.cancelEditMode = function (food) {
        food.editMode = !food.editMode;
        food.type = $scope.data.master;
        $scope.data.master = "";
        $scope.data.editFlag = false;
    };

    $scope.cancelSearchMode = function () {
        $scope.searchText = "";
    };

    $scope.set_color = function (food) {
        if (food.selected) {
            return { 'background-color': '#E1F5A9' }
        }
    };

    $scope.selectFoodType = function (food) {
        //console.log("selectFoodType = " + food.type);
        angular.forEach($scope.data.foods, function (item) {
            if (item.type === food.type) {
                //console.log("item.type === typeOfFood = " + item.type);
                item.selected = true;
                $scope.data.selectedAvailable.foodType = item.type;
                $scope.data.selectedAvailable.availableServices = angular.copy(item.available);
            } else {
                item.selected = false;
            }
        });
    };

    $scope.getActiveYes = function (item, active) {
        return item[active] ? "active" : "";
    };

    $scope.getActiveNo = function (item, active) {
        return !item[active] ? "active" : "";
    };

    $scope.editActiveYes = function (item1, active) {
        //console.log("item1.service = " + item1.service);
        var keepGoing1 = true;
        angular.forEach($scope.data.foods, function (item2) {
            if (keepGoing1) {
                if (item2.selected) {
                    var keepGoing2 = true;
                    angular.forEach(item2.available, function (item3) {
                        if (keepGoing2) {
                            if (item3.service === item1.service) {
                                //console.log("item3.service = " + item3.service);
                                item3[active] = true;
                                keepGoing2 = false;
                            }
                        }
                    });
                    keepGoing1 = false;
                }
            }
        });
    };

    $scope.editActiveNo = function (item1, active) {
        //console.log("item1.service = " + item1.service);
        var keepGoing1 = true;
        angular.forEach($scope.data.foods, function (item2) {
            if (keepGoing1) {
                if (item2.selected) {
                    var keepGoing2 = true;
                    angular.forEach(item2.available, function (item3) {
                        if (keepGoing2) {
                            if (item3.service === item1.service) {
                                //console.log("item3.service = " + item3.service);
                                item3[active] = false;
                                keepGoing2 = false;
                            }
                        }
                    });
                    keepGoing1 = false;
                }
            }
        });
    };

    // Initialization
    var keepGoing = true;
    angular.forEach($scope.data.foods, function (item) {
        if (keepGoing) {
            if (item.selected) {
                $scope.data.selectedAvailable.foodType = item.type;
                $scope.data.selectedAvailable.availableServices = angular.copy(item.available);
                keepGoing = false;
            }
        }
    });
    //    
}

angular.element(document).ready(function () {
    $('body').attr('ng-controller', 'FoodsAndServicesCtrl');
    angular.bootstrap(document, ['app']);
});



    