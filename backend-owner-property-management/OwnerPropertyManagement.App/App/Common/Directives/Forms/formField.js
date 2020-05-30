angular.module("ClcWorldApp").directive("clcFormField", function () {
    return {
        restrict: "E",
        replace: true,
        require: "^form",
        scope: {
            model: "=fieldModel",
            type: "@fieldType",
            label: "@fieldLabel",
            disabled: "=fieldDisabled",
            fieldId: "@fieldId",
            options: "=options",
            isStartDate: "=",
            isEndDate: "=",
            referenceDate: "=",
            style:"@fieldStyle",
            placeHolder: "@fieldPlaceHolder",
            info: "@fieldInfo",
            required: "=fieldRequired",
            autofocus: "=fieldAutofocus",
            name: "@fieldName",
            maxlength: "@maxlength",
            readonly: "@",
            onChange: "&onChange"

        },
        templateUrl: function (elem, attrs) {
            var type = attrs["fieldType"];

            if (attrs.maxlength === undefined) {
                attrs.maxlength = "";
            }

            switch (type) {
                case "checkbox":
                    return "/App/Common/Directives/Forms/checkFieldHtml.html";
                case "select":
                    return "/App/Common/Directives/Forms/selectFieldHtml.html";
                case "multiSelect":
                    return "/App/Common/Directives/Forms/multiSelectFieldHtml.html";
                case "textarea":
                    return "/App/Common/Directives/Forms/textareaFieldHtml.html";
                default:
                    return "/App/Common/Directives/Forms/inputFieldHtml.html";
            }
        },

        link: function (scope, element, attrs, formCtrl) {
            var inputEl = element[0].querySelector("[name]");
            // convert an input into element´s angular
            var inputNgEl = angular.element(inputEl);
            // property name
            var inputName = scope.name;
            formCtrl.$setPristine = function () {
                $('form[name="' + formCtrl.$name + '"]').find("div.form-group").removeClass("has-error");
            };

            // only apply the has-error class after the user leaves the text box
            inputNgEl.bind("blur", function () {
                element.toggleClass("has-error", (formCtrl[inputName].$invalid && !formCtrl[inputName].$pristine));
            });
        },

        controller: function ($scope, $element, $attrs) {
            $scope.getType = function (type) {
                return type == "date" ? "text" : type;
            };
            $scope.hasInfo = function () {
                return $scope.info != null && $scope.info != "" && typeof $scope.info != "undefined";
            };
            $scope.getPlaceHolder = function () {
                return $scope.placeHolder != null ? $scope.placeHolder : $scope.label;
            };

        }
    };
});