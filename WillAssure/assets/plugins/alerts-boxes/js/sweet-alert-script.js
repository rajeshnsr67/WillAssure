
 $(document).ready(function(){

              $("#alert-basic").click(function(){
                  swal("Hello world!");
              });

              $("#alert-title").click(function(){
                  swal("Here's the title!", "...and here's the text!");
              });

     //success Alert Button


              $("#btnOTPCheckSUCCESS").click(function(){
                  swal("Verified!", "Your OTP has Been Verified!,", "success");
              });
     

              $("#btnDeleteTestatorData").click(function () {
                 swal("Deleted!", "Your Data has Been Deleted!,", "success");
              });

     


     $("#btnloginSUCCESS").click(function () {
         swal("Submitted!", "Your Data has Been Submitted!,", "success");
     });


     
     // roles
     $("#btnRoleformsubmitSUCCESS").click(function () {
         swal("Roles Added!", "Your Data has Been Added!,", "success");
     });

     $("#btnRoleformsubmitCHECK").click(function () {
         swal("Failed", "Data Already Exist", "error");
     });
     $("#btnRoleDataUpdate").click(function () {
         swal("Role Updated", "Your Data has Been Updated", "success");
     });
     //end
     

     // distributor
     $("#btnDistributorformsubmitSUCCESS").click(function () {
         swal("Distributor Added", "Your Data has Been Added", "success");
     });


     $("#btnDistributorformsubmitUPDATE").click(function () {
         swal("Distributor Updated", "Your Data has Been Updated", "success");
     });

     //end



     // users

     $("#btnUserformsubmitSUCCESS").click(function () {
         swal("Records Added", "Your Data has Been Added", "success");
     });

     $("#UpdatingUserformUPDATE").click(function () {
         swal("Records Updated", "Your Data has Been Updated", "success");
     });
     
     $("#btncheckuser").click(function () {
         swal("Failed", "Login Id Already Exists", "error");
     });
    // end


     //testator
     $("#ADDTestatorFormData").click(function () {
         swal("Testator Added!", "Your Data has Been Added!,", "success");
     });

     $("#btnTestatorformsubmitUPDATE").click(function () {
         swal("Testator Updated!", "Your Data has Been Updated!,", "success");
     });



     //end

     // asset type

     $("#btnAssetformsubmitSUCCESS").click(function () {
         swal("Asset Type Added!", "Your Data has Been Added!,", "success");
     });

     $("#btnUpdateassettype").click(function () {
         swal("AssetType Updated!", "Your Data has Been Updated!,", "success");
     });

     //end


     // asset category

     $("#btnassetcategoryadded").click(function () {
         swal("AssetCategory Added!", "Your Data has Been Added!,", "success");
     });


     $("#btnassetcategoryupdated").click(function () {
         swal("AssetCategory Updated!", "Your Data has Been Updated!,", "success");
     });

     //end


     // acm
     
     $("#btnaddAssetSUCCESS").click(function () {
         swal("Asset Control Added", "Your Data has Been Added", "success");
     });
     
     $("#btnassetcontrolUpdated").click(function () {
         swal("Asset Control Updated", "Your Data has Been Updated", "success");
     });
     //end


     // btnassetinfo

     
     $("#btnassetinfosuccess").click(function () {
         swal("Asset info Added", "Your Data has Been Added", "success");
     });
     
     $("#btnassetinfoupdate").click(function () {
         swal("Asset info Updated", "Your Data has Been Updated", "success");
     });
     //end



     // relation

     


     $("#btnMemberformsubmitSUCCESS").click(function () {
         swal("Relation Added", "Your Data has Been Added", "success");
     });




     $("#btnrelationupdate").click(function () {
         swal("Relation Updated", "Your Data has Been Updated", "success");
     });


     
     $("#btnMemberformsubmitCHECK").click(function () {
         swal("Failed", "Data Already Exists", "error");
     });
     //end



     // beneficiary


     $("#btnBeneficiarySUCESS").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });

     
     $("#btnBeneficiaryupdated").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });
     
     //end


     // alt benefi
     

     $("#btnalternatebenefisuccess").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });


     $("#btnupdatealternatesucess").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });


     //end


     // nominee
     
     $("#btnnomineeinsertsuccess").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });


     $("#btnnomineeupdatesuccess").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });


     //end


     // appointees
     
     $("#btnappointeeSuccess").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });


     $("#updatesuccessappointees").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });


     //end



     // alternate appointees
     
     $("#btnalternateappointeesSuccess").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });


     $("#btnaltappointesssucess").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });


     //end


     //main asset 

     
     $("#btnmainassetsuccess").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });


     //end


     // testator family
     
     $("#btntestatorfamilysubmitSUCCESS").click(function () {
         swal("Submitted", "Your Data has Been Submitted", "success");
     });

     $("#btntestatorUPDATESUCCESS").click(function () {
         swal("Updated", "Your Data has Been Updated", "success");
     });

     //end
 
     $("#btndeleteroles").click(function () {
         swal("Role Deleted!", "Your Data has Been Deleted!,", "success");
     });


     $("#btndistributorDelete").click(function () {
         swal("Company Deleted!", "Your Data has Been Deleted!,", "success");
     });

     
     $("#btnuserformdelete").click(function () {
         swal("Distributor Deleted!", "Your Data has Been Deleted!,", "success");
     });

    


     $("#btndeletetestator").click(function () {
         swal("Testator Deleted!", "Your Data has Been Deleted!,", "success");
     });

     

     $("#btndeleteassettype").click(function () {
         swal("AssetType Deleted!", "Your Data has Been Deleted!,", "success");
     });

    





     $("#btnassetcategorydeleted").click(function () {
         swal("AssetCategory Deleted!", "Your Data has Been Deleted!,", "success");
     });


     //end

     //Failed Alert Button

     $("#btnOTPCheckFAILED").click(function(){
                  swal("Failed!", "Please Enter Correct OTP!,", "error");
              });


     $("#btnloginFAILED").click(function () {
         swal("Failed!", "Please Enter Valid Details!,", "error");
     });

     //end
     

              // page linking notification
              $("#btnuserlink").click(function(){
                  swal("Information!", "Please Fill Out Company Form First...!", "info");
              });


            $("#testatorlinkcheck").click(function () {
                swal("Information!", "Please Fill Up Distributor Details First...!", "info");
            });


             $("#testatorfamilylinkcheck").click(function () {
                 swal("Information!", "Please Fill Out Testator Form First...!", "info");
             });

     

     $("#mainassetlinkcheck").click(function () {
         swal("Information!", "Please Fill Out Testator Form First...!", "info");
     });

     

     $("#Beneficiarylinkcheck").click(function () {
         swal("Information!", "Please Fill Testator and Assets Information First...!", "info");
     });

     

     $("#btnalternatebenefilinking").click(function () {
         swal("Information!", "Please Fill Beneficiary Form First...!", "info");
     });


     
     $("#btnnomineelinking").click(function () {
         swal("Information!", "Please Fill Out AssetInformation and Testator Form First...!", "info");
     });

     
     
     $("#btnalternateappointeesLinking").click(function () {
         swal("Information!", "Please Fill out Appointees Form First...!", "info");
     });
              //end



              $("#alert-warning").click(function(){
                  swal("Warning!", "You clicked the button!,", "warning");
              });


              $("#confirm-btn-alert").click(function(){

                  swal({
                    title: "Are you sure?",
                    text: "Once deleted, you will not be able to recover this imaginary file!",
                    icon: "warning",
                    buttons: true,
                    dangerMode: true,
                  })
                  .then((willDelete) => {
                    if (willDelete) {
                      swal("Poof! Your imaginary file has been deleted!", {
                        icon: "success",
                      });
                    } else {
                      swal("Your imaginary file is safe!");
                    }
                  });

              });

          });