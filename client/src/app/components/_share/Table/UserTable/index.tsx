import { UserInfo } from "models/user/userInfo";
import moment from "moment";
import React from "react";
import Select from "react-select";
import { userApi } from "services/api/user/user";
import { toastService } from "services/toast";
import { Role, roleDefaults } from "settings/user/role";
import { Option } from "settings/_share/select";
import "./style.scss";
interface Props {
  users: UserInfo[];
  setUsers?: (users: UserInfo[]) => void;
}
const UserTable: React.FC<Props> = ({ users, setUsers }) => {
  const setUser = (user: UserInfo) => {
    var userIndex = users.findIndex((u) => u.id === user.id);
    if (userIndex !== -1) {
      setUsers && setUsers([...users].fill(user, userIndex, userIndex + 1));
    }
  };
  return (
    <table className="user-table table-bordered">
      <tbody>
        <tr className="user-table-row text-center text-bold header">
          <td className="user-table-cell">Tên đăng nhập</td>
          <td className="user-table-cell">Email</td>
          <td className="user-table-cell">Họ và tên</td>
          <td className="user-table-cell">Vai trò</td>
          <td className="user-table-cell">Trạng thái</td>
          <td className="user-table-cell">Ngày tham gia</td>
          <td className="user-table-cell">options abc</td>
        </tr>
        {users.map((user, i) => (
          <Userrow user={user} key={i} setUser={setUser} />
        ))}
      </tbody>
    </table>
  );
};

export default UserTable;
interface UserProps {
  user: UserInfo;
  setUser: (user: UserInfo) => void;
}
const Userrow: React.FC<UserProps> = ({ user, setUser }) => {
  const onChangeRoles = (roles: Option<Role>[]) => {
    user.roles = roles.map((role) => role.value);
    userApi.updateRole(user.id, user.roles).then((res) => {
      if (res.status === 200) {
        setUser(user);
        toastService.success();
      } else {
        toastService.error(res.data.message);
      }
    });
  };
  return (
    <tr className="user-table-row">
      <td className="user-table-cell">
        <a className="username" href="/">
          {user.username}
        </a>
      </td>
      <td className="user-table-cell">{user.email}</td>
      <td className="user-table-cell">{`${user.lastName} ${user.firstName}`}</td>
      <td className="user-table-cell">
        <Select
          placeholder="vai trò"
          className="user-role-select"
          isDisabled={user.roles.includes(Role.Admin)}
          isMulti
          options={roleDefaults.filter((i) => i.value !== Role.Admin)}
          onChange={onChangeRoles as any}
          getOptionLabel={(e: any) => e.name}
          value={user.roles.map((role) =>
            roleDefaults.find((i) => i.value === role)
          )}
        />
      </td>
      <td
        className="user-table-cell text-center"
        style={{ color: user.emailConfirmed ? "green" : "red" }}
      >
        {user.emailConfirmed ? "Đã xác thực" : "Chưa xác thực"}
      </td>
      <td className="user-table-cell text-center">
        {moment(user.createdAt).format("DD/MM/YYYY")}
      </td>
      <td className="user-table-cell"></td>
    </tr>
  );
};
