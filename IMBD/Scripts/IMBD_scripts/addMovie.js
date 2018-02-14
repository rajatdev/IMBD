
    function AddingProducer() {
        $.ajax({
            type: "POST",
            url: "/Producers/AddProducer",
            data: $("#ProducerForm").serialize(),
            success: function (response) {
                var message = "Name:" + response.ModalName;
                message += "\nBio: " + response.ModalBio;
                message += "\nSex: " + response.ModalSex;
                message += "Id=" + response.ModalId;

                var newOption = "<option value='" + response.ModalId + "'>" + response.ModalName + "</option>";



                $("#Producerdd").append(newOption);
                $('#Producerdd').trigger('change.select2');
                //    $("#ProducerModal").modal('hide');
                alert(message);

                $('#ProducerModal').modal('toggle');

            },
            failure: function (response) {
                alert("Error occured.");
            }
        });
    }

    function AddingActor() {
        $.ajax({
            type: "POST",
            url: "/Actors/AddActor",
            data: $("#ActorForm").serialize(),
            success: function (response) {
                var message = "Name:" + response.ModalName;
                message += "\nBio: " + response.ModalBio;
                message += "\nSex: " + response.ModalSex;
                message += "Id=" + response.ModalId;

                var newOption = "<option value='" + response.ModalId + "'>" + response.ModalName + "</option>";



                $("#Actordd").append(newOption);
                $('#Actordd').trigger('change.select2');
                //    $("#ProducerModal").modal('hide');
                alert(message);
                $('#ActorModal').modal('toggle');

            },
            failure: function (response) {
                alert("Error occured.");
            }
        });
}

   

    $('#Actordd').select2();
    $('#Producerdd').select2();

