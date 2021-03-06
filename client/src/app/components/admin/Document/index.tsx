// import { useGrades } from "hooks/Grade-Subject/useGrades";
import React from "react";
import { Redirect, Route, Switch } from "react-router";
import { routes } from "./routes";
import "./style.scss";
const Document = () => {
  //   const { grades } = useGrades();
  return (
    <Switch>
      {routes.map((route, i) => (
        <Route key={i} {...route} />
      ))}
      <Redirect from="/admin/document" to={`/admin/document/grade-10`} />
    </Switch>
  );
};

export default Document;
