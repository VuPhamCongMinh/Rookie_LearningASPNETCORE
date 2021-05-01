import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { Pagination, PaginationItem, PaginationLink } from "reactstrap";
import { setPage } from "../redux/slices/pagination_slice";
import { scrollToProduct } from "../utils/form_util";

const PaginationCustom = ({ linksNum }) => {
  const pagination = useSelector((state) => state.pagination);
  const dispatch = useDispatch();

  const setPagination = (page) => {
    dispatch(setPage(page));
    scrollToProduct();
  };

  return (
    <Pagination size="lg" aria-label="Page navigation example">
      <PaginationItem>
        <PaginationLink first onClick={() => setPagination(0)} />
      </PaginationItem>
      <PaginationItem>
        <PaginationLink
          previous
          onClick={() => {
            if (pagination - 1 >= 0) {
              dispatch(setPage(pagination - 1));
            }
          }}
        />
      </PaginationItem>
      {linksNum &&
        Array.from(Array(linksNum), (_, index) => {
          return (
            <PaginationItem
              key={`pagination-${index}`}
              className={pagination === index ? "active" : null}
            >
              <PaginationLink onClick={() => setPagination(index)}>
                {index + 1}
              </PaginationLink>
            </PaginationItem>
          );
        })}
      <PaginationItem>
        <PaginationLink
          next
          onClick={() => {
            if (pagination + 1 < linksNum) {
              setPagination(pagination + 1);
            }
          }}
        />
      </PaginationItem>
      <PaginationItem>
        <PaginationLink
          last
          onClick={() => {
            setPagination(linksNum - 1);
          }}
        />
      </PaginationItem>
    </Pagination>
  );
};

export default PaginationCustom;
