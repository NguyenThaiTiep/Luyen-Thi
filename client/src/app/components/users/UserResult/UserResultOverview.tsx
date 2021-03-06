import { Grid } from "@material-ui/core";
import { UserResultBugget } from "app/components/_share/Bugget/UserResultBugget";
import UserAnalyticResult from "app/components/_share/Chart/UserAnalyticResult";
import { ClosedBook, CheckedCheckbox, AlarmClock } from "assets/images/user";
import { useAppContext } from "hooks/AppContext";
import {
  UserHistoryAnalytic,
  UserHistoryAnalyticQuery,
  UserHistoryTypeTime,
  UserResultAnalytic,
} from "models/user/userResult";
import React, { useEffect, useState } from "react";
import Select from "react-select";
import { profileApi } from "services/api/user/profile";
import { TimeFunction } from "utils/timeFunction";
import UserAnalyticGrade from "app/components/_share/Chart/UserAnalyticGrade";
import { Col, Row } from "react-bootstrap";
import UserAnalyticSubject from "app/components/_share/Chart/UserAnalyticSubject";

const UserResultOverview = () => {
  const { timeZone } = useAppContext();
  const [userAnalyticResult, setUserAnalyticResult] =
    useState<UserResultAnalytic>();
  const [userHistories, setUserHistories] = useState<UserHistoryAnalytic[]>([]);
  const [historyAnalyticQuery, setHistoryAnalyticQuery] =
    useState<UserHistoryAnalyticQuery>({
      type: UserHistoryTypeTime.InMonth,
    });
  useEffect(() => {
    profileApi.getAnalytic().then((res) => {
      if (res.status === 200) {
        setUserAnalyticResult(res.data);
      }
    });
  }, []);
  useEffect(() => {
    profileApi
      .getHistories({ ...historyAnalyticQuery, timeZone: timeZone })
      .then((res) => {
        if (res.status === 200) {
          setUserHistories(res.data);
        }
      });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [historyAnalyticQuery]);
  return (
    <div id="overview">
      <h5 className="label mt-1">Tổng quan</h5>
      <div className="list-bugget mt-3">
        <Grid container spacing={5}>
          <Grid item lg={4} md={4} sm={12}>
            <UserResultBugget
              image={AlarmClock}
              title="Luyện tập"
              number={TimeFunction.convertMinutes(
                userAnalyticResult?.totalTime || 0
              )}
              color="#263197"
            />
          </Grid>
          <Grid item lg={4} md={4} sm={12}>
            <UserResultBugget
              image={ClosedBook}
              title="Đã làm"
              number={`${userAnalyticResult?.numberDocument || 0} tài liệu`}
              color="#C9512B"
            />
          </Grid>
          <Grid item lg={4} md={4} sm={12}>
            <UserResultBugget
              image={CheckedCheckbox}
              title="Chính xác"
              number={`${userAnalyticResult?.percentCorrect || 0}%`}
              color="#2BC986"
            />
          </Grid>
        </Grid>
      </div>
      <div className="label-inlne d-flex">
        <h5 className="label mt-4 mb-3" style={{ flexGrow: 1 }}>
          Tần suất hoạt động
        </h5>
        <div className="select-option">
          <Select
            className="select"
            options={timeDurationValues as any}
            onChange={(e: any) =>
              setHistoryAnalyticQuery({
                ...historyAnalyticQuery,
                type: e.value,
              })
            }
            value={timeDurationValues.find(
              (i) => i.value === historyAnalyticQuery.type
            )}
          />
        </div>
      </div>
      <div className="analytic-chart-result">
        <UserAnalyticResult userHistoies={userHistories} />
      </div>
      <div className="label-inlne d-flex">
        <h5 className="label mt-4 mb-3" style={{ flexGrow: 1 }}>
          Đánh giá chung
        </h5>
      </div>
      <div className="analytic-chart-overview">
        <Row>
          <Col>
            <UserAnalyticGrade
              values={[30, 50, 30]}
              labels={["Lớp 10", "Lớp 11", "Lớp 12"]}
            />
          </Col>
          <Col>
            <UserAnalyticGrade
              values={[5, 5, 5, 5]}
              labels={["Nhận biết", "Thông hiểu", "Vận dụng", "Vận dụng cao"]}
            />
          </Col>
        </Row>
        <h5 className="label mt-4 mb-3" style={{ flexGrow: 1 }}>
          Đánh giá theo môn học
        </h5>
        <Row>
          <UserAnalyticSubject />
        </Row>
      </div>
    </div>
  );
};

export default UserResultOverview;
const timeDurationValues = [
  {
    value: UserHistoryTypeTime.Today,
    label: "Hôm nay",
  },
  {
    value: UserHistoryTypeTime.InWeek,
    label: "Tuần này",
  },
  {
    value: UserHistoryTypeTime.InMonth,
    label: "Tháng này",
  },
  {
    value: UserHistoryTypeTime.InYear,
    label: "Năm nay",
  },
];
