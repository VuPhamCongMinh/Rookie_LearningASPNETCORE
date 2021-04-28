import Swal from "sweetalert2";

export const alertSuccess = (title) => {
  Swal.fire({
    title: `${title} thành công !`,
    icon: "success",
    confirmButtonText: "Cool",
  });
};

export const alertConfirm = (deleteCallback, id) => {
  Swal.fire({
    title: "Bạn có chắc chưa ?",
    text: "Một đi không trở lại",
    icon: "warning",
    showCancelButton: true,
    confirmButtonColor: "#3085d6",
    cancelButtonColor: "#d33",
    cancelButtonText: "Cancel",
    confirmButtonText: "Delete",
  }).then((result) => {
    if (result.isConfirmed) {
      deleteCallback(id);
    }
  });
};

export const alertError = (title) => {
  Swal.fire({
    title: `${title} thất bại !`,
    icon: "error",
    confirmButtonText: ":(",
  });
};
