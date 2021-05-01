import { createSlice } from "@reduxjs/toolkit";

const initialState = 0;

const paginationSlice = createSlice({
  name: "pagination",
  initialState,
  reducers: {
    setPage(state, { payload }) {
      return (state = payload);
    },
    nextPage(state, { payload }) {
      return (state += payload);
    },
    previousPage(state, { payload }) {
      return (state -= payload);
    },
  },
});

export const { nextPage, previousPage, setPage } = paginationSlice.actions;
export default paginationSlice.reducer;
