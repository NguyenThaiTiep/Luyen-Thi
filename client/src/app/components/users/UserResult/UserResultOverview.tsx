import { Grid } from "@material-ui/core";
import { UserResultBugget } from "app/components/_share/Bugget/UserResultBugget";
import UserAnalyticResult from "app/components/_share/Chart/UserAnalyticResult";
import { AlarmClock, ClosedBook, CheckedCheckbox } from "assets/images";
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

const UserResultOverview = () => {
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
    profileApi.getHistories(historyAnalyticQuery).then((res) => {
      if (res.status === 200) {
        setUserHistories(res.data);
      }
    });
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
              number={`${userAnalyticResult?.numberDocument} tài liệu`}
              color="#C9512B"
            />
          </Grid>
          <Grid item lg={4} md={4} sm={12}>
            <UserResultBugget
              image={CheckedCheckbox}
              title="Chính xác"
              number={`${userAnalyticResult?.percentCorrect}%`}
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
            defaultValue={timeDurationValues[2]}
          />
        </div>
      </div>
      <div className="analytic-chart-result">
        <UserAnalyticResult userHistoies={userHistories} />
      </div>
      <div className="anayltic-chart-overview"></div>
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