import { Grid } from "@material-ui/core";
import { Similar } from "app/components/_share/Similer";
import React, { useEffect, useState } from "react";
import "./style.scss";
import { Book, Folder } from "@material-ui/icons";
import { Budget } from "./Bugget";
import { UserCheck } from "react-feather";
import ActionUser from "./ActionUser";
import { useGrades } from "hooks/Grade-Subject/useGrades";
import { useSubjects } from "hooks/Grade-Subject/useSubjects";
import { analyticApi } from "services/api/analytic/analytic";

interface InfoAnalyticSystem {
  documentQuality: number;
  questionQuality: number;
  userQuality: number;
}

const Dashboard = () => {
  const { grades } = useGrades();
  const { subjects } = useSubjects();
  const [infoAnalyticSystem, setInfoAnalyticSystem] =
    useState<InfoAnalyticSystem>();
  useEffect(() => {
    analyticApi.getAnalyticSystem().then((res) => {
      setInfoAnalyticSystem(res.data.analyticSystem);
    });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  return (
    <div className="admin-main-content admin-dash-board">
      <Grid container spacing={2}>
        <Grid item lg={9} md={12}>
          <h4>Thống kê chung</h4>
          {/* bugget  */}
          <div className="list-bugget">
            <Grid container spacing={3} className="justify-content-center my-3">
              <Grid item lg={3} sm={6} xl={3} xs={12}>
                <Budget
                  title={"Tài liệu"}
                  amount={infoAnalyticSystem?.documentQuality}
                  icon={<Book />}
                  color="green"
                />
              </Grid>
              <Grid item lg={3} sm={6} xl={3} xs={12}>
                <Budget
                  title={"Câu hỏi"}
                  amount={infoAnalyticSystem?.questionQuality}
                  icon={<Folder />}
                  color="orange"
                />
              </Grid>
              {/* <Grid item lg={3} sm={6} xl={3} xs={12}>
                <Budget
                  title={"Lớp học"}
                  amount={100}
                  icon={<Folder />}
                  color="blue"
                />
              </Grid> */}
              <Grid item lg={3} sm={6} xl={3} xs={12}>
                <Budget
                  title={"Người dùng"}
                  amount={infoAnalyticSystem?.userQuality}
                  icon={<UserCheck />}
                  color="green"
                />
              </Grid>
            </Grid>
          </div>
          <ActionUser />
          {/* <h4 className="mt-3">Gần đây</h4>
          <div className="new-action mt-3">
            <Grid container spacing={3}>
              <Grid item lg={3} sm={6} xl={3} xs={12}>
                <Budget
                  title={"Đề thi thử"}
                  amount={100}
                  icon={<Book />}
                  color="green"
                />
              </Grid>
              <Grid item lg={3} sm={6} xl={3} xs={12}>
                <Budget
                  title={"Bộ CH"}
                  amount={100}
                  icon={<Folder />}
                  color="orange"
                />
              </Grid>
              <Grid item lg={3} sm={6} xl={3} xs={12}>
                <Budget
                  title={"User"}
                  amount={100}
                  icon={<Folder />}
                  color="blue"
                />
              </Grid>
              <Grid item lg={3} sm={6} xl={3} xs={12}>
                <Budget
                  title={"Nhà trọ"}
                  amount={100}
                  icon={<UserCheck />}
                  color="green"
                />
              </Grid>
            </Grid>
          </div> */}
          {/* <h4 className="mt-3">Xem nhiều nhất</h4>
            <div className="see-many">
              <DocumentSeeMany />
            </div> */}
        </Grid>
        <Grid item lg={3} md={12}>
          <Grid item className="mb-2" lg={12}>
            <Similar title="Tài liệu theo lớp" list={grades} />
          </Grid>
          <Grid lg={12}>
            <Similar title="Tài liệu theo môn học" list={subjects} />
          </Grid>
        </Grid>
      </Grid>
    </div>
  );
};

export default Dashboard;
