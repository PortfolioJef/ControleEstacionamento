var ConfirmDelete = function (ValetId, ValetName) {
    
    $("#hiddenValetId").val(ValetId);
    $("#deleteModal").modal('show');
    $("#lblNameManobrista").text(ValetName);
}

var delValet = function () {
    var ValetId = $("#hiddenValetId").val();
    alert(ValetId);
    $.ajax({

        type: "POST",
        url: "/Valet/DeleteConfirmed",
        data: { id: ValetId },
        success: function (result) {
            alert(ValetId);
            $("#myModal").modal("hide");
            $("#row_" + ValetId).remove();

        }

    });
};

//Parking

 

var ConfirmDeleteParking = function (ParkingId, CarIdentification) {

    $("#hiddenValetId").val(ValetId);
    $("#deleteModal").modal('show');
    $("#lblNameManobrista").text(CarIdentification);
}

var delParking = function () {
    var ParkingId = $("#hiddenParkingId").val();
    alert(ParkingId);
    $.ajax({

        type: "POST",
        url: "/Parking/DeleteConfirmed",
        data: { id: ParkingId },
        success: function (result) {
            alert(ParkingId);
            $("#myModal").modal("hide");
            $("#row_" + ParkingId).remove();

        }

    });
};