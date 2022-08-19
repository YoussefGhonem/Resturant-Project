import { SweetAlertOptions } from "sweetalert2";

export const sweetAlertOptions: SweetAlertOptions = {
  toast: false,
  // iconColor: '#28c76f',
  // animation: true,
  // position: 'top-right',
  icon: null,
  showConfirmButton: false,
  showCloseButton: false,
  showCancelButton: true,
  cancelButtonText: 'Dismiss',
  buttonsStyling: false,
  customClass: {
    cancelButton: 'swal2-cancel btn btn-primary w-xs mb-1'
  },
  // timer: 5000,
  // timerProgressBar: true,
}
