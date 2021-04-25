import { createSlice } from "@reduxjs/toolkit";

const initialState = [];

const accountSlice = createSlice({
  name: "account",
  initialState,
  reducers: {
    setUsers(state, { payload }) {
      return payload;
    },
  },
});

export const { setUsers } = accountSlice.actions;
export default accountSlice.reducer;
