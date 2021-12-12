import ReactApexChart from "react-apexcharts";
import ApexCharts from "apexcharts";
import React, { useEffect, useMemo, useState } from "react";
import { PracticeTime } from "settings/practice/practiceTime";
import { documentApi } from "services/api/document/documentApi";
import { Form } from "react-bootstrap";

type UserAnalysisChartProps = {
  templateId: string;
};

const UserAnalysisChart = ({ templateId }: UserAnalysisChartProps) => {
  const [scores, setScores] = useState<Array<number>>([]);
  const [timeSelect, setTimeSelect] = useState(PracticeTime.WEEK);

  const chartOptions = useMemo(() => {
    const options: ApexCharts.ApexOptions = {
      chart: {
        height: 350,
        type: "line",
        toolbar: {
          show: false,
        },
        zoom: {
          enabled: false,
        },
      },
      dataLabels: {
        enabled: false,
      },
      stroke: {
        curve: "smooth",
        width: 2,
      },
      grid: {
        row: {
          colors: ["#f3f3f3", "transparent"],
          opacity: 0.5,
        },
      },
      xaxis: {
        categories: [...scores.map((_, i) => i + 1)],
      },
    };
    return options;
  }, [scores]);

  const charSeries = useMemo(() => {
    const series = [
      {
        name: "Điểm số",
        data: scores,
      },
    ];
    return series;
  }, [scores]);

  const selectOnchangeHandler = (
    event: React.ChangeEvent<HTMLSelectElement>
  ) => {
    const value = event?.target?.value as unknown as PracticeTime;
    if (value !== timeSelect) {
      setTimeSelect(value);
    }
  };

  useEffect(() => {
    documentApi.getAnalysis(templateId, timeSelect).then((response) => {
      if (response.status === 200 && response.data) {
        const histories = response.data.historyPractice;
        if (histories?.length > 0) {
          const scores = histories.map((e) => e.score);
          setScores(scores);
        }
      }
    });
  }, [templateId, timeSelect]);

  return (
    <React.Fragment>
      <Form>
        <Form.Group controlId="exampleForm.SelectCustom">
          <Form.Control
            value={timeSelect}
            as="select"
            custom
            onChange={selectOnchangeHandler}
          >
            <option value={PracticeTime.WEEK}>Theo tuần</option>
            <option value={PracticeTime.MONTH}>Theo tháng</option>
            <option value={PracticeTime.YEAR}>Theo năm</option>
          </Form.Control>
        </Form.Group>
      </Form>
      <div id="chart">
        {scores?.length > 0 && (
          <ReactApexChart
            options={chartOptions}
            series={charSeries}
            type="area"
            height={350}
          />
        )}
      </div>
    </React.Fragment>
  );
};

export default React.memo(UserAnalysisChart);
