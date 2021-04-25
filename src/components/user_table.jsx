import React, { useEffect } from "react";
import { useSelector } from "react-redux";
import { Table } from "reactstrap";

export const UserTable = () => {
  const userList = useSelector((state) => state.account);

  return (
    <Table responsive={true} striped={true}>
      <thead>
        <tr>
          <th>#</th>
          <th>Id</th>
          <th>Username</th>
          <th>Email</th>
        </tr>
      </thead>
      <tbody>
        {userList.map((user, index) => {
          return (
            <tr key={user.id}>
              <th className="align-middle" scope="row">
                {index + 1}
              </th>
              <td className="align-middle">$ {user.id}</td>
              <td className="align-middle">{user.userName}</td>
              <td className="align-middle">{user.email}</td>
            </tr>
          );
        })}
      </tbody>
    </Table>
  );
};
